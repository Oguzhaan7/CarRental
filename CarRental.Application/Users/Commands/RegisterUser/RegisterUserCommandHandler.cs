using AutoMapper;
using CarRental.Application.Common.Interfaces.Authentication;
using CarRental.Application.Common.Interfaces.Persistance;
using CarRental.Application.Common.Responses;
using CarRental.Application.Users.Common;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Response<UserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordService _passwordService;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, IJwtTokenGenerator jwtTokenGenerator, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordService = passwordService;
        }

        public async Task<Response<UserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(x => x.Email == request.Email);

            if (user is not null)
            {
                return Response<UserResponse>.FailResponse("This email address is already registered", null);
            }

            user = _mapper.Map<User>(request);

            user.Password = _passwordService.HashPassword(request.Password);
            user.CreatedDateTime = DateTime.UtcNow;
            user.UpdatedDateTime = DateTime.UtcNow;

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            var token = _jwtTokenGenerator.GenerateToken(user);

            var userMap = _mapper.Map<UserResponse>(user);
            userMap.Token = token;

            return Response<UserResponse>.SuccessResponse("The user has been successfully added",userMap);

        }
    }
}
