using AutoMapper;
using CarRental.Application.Cars.Common;
using CarRental.Application.Common.Interfaces.Persistance;
using CarRental.Application.Common.Responses;
using CarRental.Application.Invoices.Common;
using CarRental.Application.Payments.Common;
using CarRental.Application.Rentals.Common;
using CarRental.Application.Users.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Rentals.Quieries.GetRentalById
{
    public class GetRentalByIdQueryHandler : IRequestHandler<GetRentalByIdQuery, Response<RentalResponse>>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetRentalByIdQueryHandler(IRentalRepository rentalRepository, IMapper mapper, IUserRepository userRepository, ICarRepository carRepository)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _carRepository = carRepository;
        }

        public async Task<Response<RentalResponse>> Handle(GetRentalByIdQuery request, CancellationToken cancellationToken)
        {
            var rental = await _rentalRepository.GetByIdAsync(x=>x.Id == request.Id, x=>x.Invoice, x=>x.Payments);

            if (rental is null)
                return Response<RentalResponse>.FailResponse("Rental record not found", null);

            return Response<RentalResponse>.SuccessResponse("Rental record successfully retrieved", _mapper.Map<RentalResponse>(rental));
        }
    }
}
