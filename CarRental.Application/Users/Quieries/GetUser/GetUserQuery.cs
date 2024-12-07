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
    public record GetUserQuery(Guid Id) : IRequest<Response<UserResponse>>;
}
