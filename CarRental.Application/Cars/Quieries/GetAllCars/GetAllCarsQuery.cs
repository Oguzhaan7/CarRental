using CarRental.Application.Cars.Common;
using CarRental.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Cars.Quieries.GetAllCars
{
    public record GetAllCarsQuery : IRequest<Response<List<CarResponse>>>;
}
