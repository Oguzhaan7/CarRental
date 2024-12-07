using CarRental.Application.Cars.Common;
using CarRental.Application.Common.FilterExtensions;
using CarRental.Application.Common.Responses;
using MediatR;

namespace CarRental.Application.Cars.Quieries.GetCarsByFilters
{
    public record GetCarsByFiltersQuery(List<List<FilterValue>> Filters) : IRequest<Response<List<CarResponse>>>;
}
