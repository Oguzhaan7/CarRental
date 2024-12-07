using AutoMapper;
using CarRental.Application.Cars.Common;
using CarRental.Application.Common.FilterExtensions;
using CarRental.Application.Common.Interfaces.Persistance;
using CarRental.Application.Common.Responses;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Cars.Quieries.GetCarsByFilters
{
    public class GetCarsByFiltersQueryHandler : IRequestHandler<GetCarsByFiltersQuery, Response<List<CarResponse>>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetCarsByFiltersQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<CarResponse>>> Handle(GetCarsByFiltersQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Car> query = _carRepository.AsQueryable();

            query = FilterData.Filter(query, request.Filters);

            if (!query.Any())
                return Response<List<CarResponse>>.FailResponse("No results found for the applied filters", null );

            return Response<List<CarResponse>>.SuccessResponse("The results have been successfully retrieved", _mapper.Map<List<CarResponse>>(query));
        }
    }
}
