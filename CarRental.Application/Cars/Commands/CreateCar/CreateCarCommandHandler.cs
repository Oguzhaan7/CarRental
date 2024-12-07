using AutoMapper;
using CarRental.Application.Cars.Common;
using CarRental.Application.Common.Interfaces.Persistance;
using CarRental.Application.Common.Responses;
using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Cars.Commands.CreateCar
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Response<CarResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<Response<CarResponse>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = _mapper.Map<Car>(request.Car);

            car.CreatedDateTime = DateTime.UtcNow;
            car.UpdatedDateTime = DateTime.UtcNow;

            await _carRepository.AddAsync(car);
            await _carRepository.SaveChangesAsync();
            return Response<CarResponse>.SuccessResponse("The car has been successfully added", _mapper.Map<CarResponse>(car));
        }
    }
}
