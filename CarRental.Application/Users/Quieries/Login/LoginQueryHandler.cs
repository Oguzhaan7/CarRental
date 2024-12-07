using AutoMapper;
using CarRental.Application.Common.Interfaces.Authentication;
using CarRental.Application.Common.Interfaces.Persistance;
using CarRental.Application.Common.Responses;
using CarRental.Application.Users.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Users.Quieries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, Response<UserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginQueryHandler(IUserRepository userRepository, IMapper mapper, IPasswordService passwordService, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordService = passwordService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Response<UserResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(x => x.Email == request.Email);

            if (user is null)
                return Response<UserResponse>.FailResponse("The user could not be found", null);

            var isVerify = _passwordService.VerifyPassword(request.Password, user.Password);

            if (!isVerify)
                return Response<UserResponse>.FailResponse("The password is incorrect", null);

            var token = _jwtTokenGenerator.GenerateToken(user);

            var userMap = _mapper.Map<UserResponse>(user);
            userMap.Token = token;

            return Response<UserResponse>.SuccessResponse("The login process has been successful", userMap);
        }
    }
}
