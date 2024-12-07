using AutoMapper;
using CarRental.Application.Cars.Common;
using CarRental.Application.Common.Interfaces.Persistance;
using CarRental.Application.Common.Responses;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Cars.Commands.UpdateCar
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Response<CarResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<Response<CarResponse>> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByIdAsync(request.Id, true);
            var createdDateTime = car.CreatedDateTime;
            if (car is null)
                return Response<CarResponse>.FailResponse("The car could not be found", null);

            car = _mapper.Map<Car>(request.Car);
            car.Id = request.Id;
            car.UpdatedDateTime = DateTime.UtcNow;
            car.CreatedDateTime = createdDateTime;

            await _carRepository.UpdateAsync(car);
             
            await _carRepository.SaveChangesAsync();

            return Response<CarResponse>.SuccessResponse("The car has been successfully updated.", _mapper.Map<CarResponse>(car));
        }
    }
}
