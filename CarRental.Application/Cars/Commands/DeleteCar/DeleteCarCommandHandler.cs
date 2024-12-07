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

namespace CarRental.Application.Cars.Commands.DeleteCar
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, Response<CarResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<Response<CarResponse>> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            Car car = await _carRepository.GetByIdAsync(x=>x.Id == request.Id);

            if (car is null)
                return Response<CarResponse>.FailResponse("The car could not be found", null);

            await _carRepository.DeleteAsync(car);
            await _carRepository.SaveChangesAsync();
            return Response<CarResponse>.SuccessResponse("The car has been successfully deleted", _mapper.Map<CarResponse>(car));
        }
    }
}
