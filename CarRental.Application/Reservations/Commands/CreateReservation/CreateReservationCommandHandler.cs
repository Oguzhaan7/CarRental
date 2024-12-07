using AutoMapper;
using CarRental.Application.Common.Interfaces.Persistance;
using CarRental.Application.Common.Responses;
using CarRental.Application.Common.Validations;
using CarRental.Application.Reservations.Common;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Response<ReservationResponse>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CreateReservationCommandHandler(IReservationRepository reservationRepository, ICarRepository carRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<Response<ReservationResponse>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            DateValidation.ValidateDate(request.Reservation.StartDate, request.Reservation.EndDate);

            if (request.Reservation.StartDate.AddDays(-1) < DateTime.UtcNow)
                return Response<ReservationResponse>.FailResponse("The car is not available for reservation", null);

            Car car = await _carRepository.GetByIdAsync(x=>x.Id == request.Reservation.CarId, x=>x.Reservations);

            DateRange requestRange = new DateRange(request.Reservation.StartDate, request.Reservation.EndDate);
            bool isDateRangeInside = false;

            foreach (var carReservation in car.Reservations)
            {
                DateRange reservationRange = new DateRange(carReservation.StartDate, carReservation.EndDate);

                isDateRangeInside = DateValidation.IsDateRangeInside(requestRange, reservationRange);

                if (isDateRangeInside)
                    break;
            }

            if(isDateRangeInside)
                return Response<ReservationResponse>.FailResponse("The car is not available for reservation", null);

            Reservation reservation = _mapper.Map<Reservation>(request.Reservation);
            reservation.CreatedDateTime = DateTime.UtcNow;
            reservation.UpdatedDateTime = DateTime.UtcNow;
            reservation.ReservationExpireDate = request.Reservation.StartDate.AddDays(-1);
            reservation.ReservationStatus = Domain.Enums.ReservationStatus.Pending;

            await _reservationRepository.AddAsync(reservation);
            await _reservationRepository.SaveChangesAsync();
            await _carRepository.SaveChangesAsync();

            return Response<ReservationResponse>.SuccessResponse("The reservation has been successfully created", _mapper.Map<ReservationResponse>(reservation));
        }
    }
}
