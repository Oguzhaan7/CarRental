using AutoMapper;
using CarRental.Application.Common.Interfaces.Persistance;
using CarRental.Application.Common.Responses;
using CarRental.Application.Reservations.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, Response<ReservationResponse>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public UpdateReservationCommandHandler(IReservationRepository reservationRepository, ICarRepository carRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public Task<Response<ReservationResponse>> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
