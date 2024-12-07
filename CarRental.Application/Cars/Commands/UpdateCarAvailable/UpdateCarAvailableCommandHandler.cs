using CarRental.Application.Common.Interfaces.Persistance;
using CarRental.Application.Common.Responses;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Cars.Commands.UpdateCarAvailable
{
    public class UpdateCarAvailableCommandHandler : IRequestHandler<UpdateCarAvailableCommand, Response>
    {
        private readonly ICarRepository _carRepository;

        public UpdateCarAvailableCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Response> Handle(UpdateCarAvailableCommand request, CancellationToken cancellationToken)
        {
            Car car = await _carRepository.GetByIdAsync(request.Id);

            if (car is null)
                return Response.FailResponse("The car could not be found");

            if (car.IsAvailable)
                return Response.FailResponse("This car is already available for rental");

            car.IsAvailable = true;
            await _carRepository.SaveChangesAsync();

            return Response.SuccessResponse("This car's rental status has been updated");
        }
    }
}
