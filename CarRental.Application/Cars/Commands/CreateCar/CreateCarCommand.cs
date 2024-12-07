using CarRental.Application.Cars.Common;
using CarRental.Application.Common.Responses;
using CarRental.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Cars.Commands.CreateCar
{
    public record CreateCarCommand(CarRequest Car) : IRequest<Response<CarResponse>>;
}
