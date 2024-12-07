using CarRental.Application.Common.Responses;
using CarRental.Application.Reservations.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Reservations.Commands.CreateReservation
{
    public record CreateReservationCommand(ReservationRequest Reservation) : IRequest<Response<ReservationResponse>>;
}
