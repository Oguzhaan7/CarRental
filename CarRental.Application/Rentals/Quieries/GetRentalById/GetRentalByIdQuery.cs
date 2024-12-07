using CarRental.Application.Common.Responses;
using CarRental.Application.Rentals.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Rentals.Quieries.GetRentalById
{
    public record GetRentalByIdQuery(Guid Id) : IRequest<Response<RentalResponse>>;
}
