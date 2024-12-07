using CarRental.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Cars.Commands.UpdateCarAvailable
{
    public record UpdateCarAvailableCommand(Guid Id) : IRequest<Response>;
}
