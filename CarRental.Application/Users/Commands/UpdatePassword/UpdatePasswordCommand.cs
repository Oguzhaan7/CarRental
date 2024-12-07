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
    public record UpdatePasswordCommand(string Email, string OldPassword, string Password) : IRequest<Response<UserResponse>>;
}
