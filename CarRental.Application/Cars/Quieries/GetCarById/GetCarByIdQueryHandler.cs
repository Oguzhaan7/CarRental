using AutoMapper;
using CarRental.Application.Cars.Common;
using CarRental.Application.Common.Exceptions;
using CarRental.Application.Common.Interfaces.Persistance;
using CarRental.Application.Common.Responses;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Cars.Quieries.GetCarById
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, Response<CarResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetCarByIdQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<Response<CarResponse>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            Car car = await _carRepository.GetByIdAsync(x=>x.Id == request.Id, x=>x.Rentals);

            if (car is null)
                throw new NotFoundException("The car could not be found");

            return Response<CarResponse>.SuccessResponse("The car has been successfully retrieved", _mapper.Map<CarResponse>(car));
        }
    }
}
