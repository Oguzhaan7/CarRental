using CarRental.Application.Common.Responses;
using CarRental.Application.Users.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Users.Commands.RegisterUser
{
    public record RegisterUserCommand(string FirstName, string LastName, string Email, string Password, string PhoneNumber) : IRequest<Response<UserResponse>>;
}
