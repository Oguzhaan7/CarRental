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

namespace CarRental.Application.Users.Commands.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, Response<UserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;

        public UpdatePasswordCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IPasswordService passwordService, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordService = passwordService;
            _mapper = mapper;
        }

        public async Task<Response<UserResponse>> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(x => x.Email == request.Email);

            if (user is null)
                return Response<UserResponse>.FailResponse("The user could not be found", null);

            var isVerify = _passwordService.VerifyPassword(request.OldPassword, user.Password);

            if (!isVerify)
                return Response<UserResponse>.FailResponse("The previous password is incorrect", null);

            string hashedPassword = _passwordService.HashPassword(request.Password);

            user.Password = hashedPassword;

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();

            var token = _jwtTokenGenerator.GenerateToken(user);

            var userMap = _mapper.Map<UserResponse>(user);
            userMap.Token = token;

            return Response<UserResponse>.SuccessResponse("The password has been successfully changed", userMap);
        }
    }
}
