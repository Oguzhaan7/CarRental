using CarRental.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Users.Quieries.ValidateToken
{
    public record ValidateTokenQuery(string Token) : IRequest<Response>;
}
