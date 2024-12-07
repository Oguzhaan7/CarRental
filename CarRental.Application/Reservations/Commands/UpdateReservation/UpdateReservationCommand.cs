using CarRental.Application.Common.Responses;
using CarRental.Application.Payments.Common;
using CarRental.Application.Reservations.Common;
using CarRental.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Reservations.Commands.UpdateReservation
{
    public record UpdateReservationCommand(Guid Id, ReservationStatus ReservationStatus, PaymentRequest PaymentRequest) : IRequest<Response<ReservationResponse>>;
}
