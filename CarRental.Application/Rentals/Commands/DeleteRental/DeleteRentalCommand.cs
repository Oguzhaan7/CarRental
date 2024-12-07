using CarRental.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Rentals.Commands.DeleteRental
{
    public record DeleteRentalCommand(Guid Id) : IRequest<Response>;
}
