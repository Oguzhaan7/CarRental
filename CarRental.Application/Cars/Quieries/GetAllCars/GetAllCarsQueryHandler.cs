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

namespace CarRental.Application.Cars.Quieries.GetAllCars
{
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, Response<List<CarResponse>>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetAllCarsQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<CarResponse>>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            List<Car> cars = await _carRepository.GetAllAsync();

            if (cars is null)
                return Response<List<CarResponse>>.FailResponse("The car could not be found", null);

            cars = cars.OrderBy(x => x.Brand).ToList();

            return Response<List<CarResponse>>.SuccessResponse("The car list has been successfully retrieved", _mapper.Map<List<CarResponse>>(cars));
        }
    }
}
