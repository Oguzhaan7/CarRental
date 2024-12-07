using AutoMapper;
using CarRental.Application.Common.Interfaces.Persistance;
using CarRental.Application.Common.Responses;
using CarRental.Application.Users.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Users.Quieries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Response<UserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response<UserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(x => x.Id == request.Id);

            if (user is null)
                return Response<UserResponse>.FailResponse("The user could not be found", null);

            var userMap = _mapper.Map<UserResponse>(user);

            return Response<UserResponse>.SuccessResponse("The user information has been successfully retrieved", userMap);
        }
    }
}
