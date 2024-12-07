using AutoMapper;
using CarRental.Application.Cars.Common;
using CarRental.Domain.Entities;

namespace CarRental.Application.Common.Mappings
{
    public class CarMapping : Profile
    {
        public CarMapping()
        {
            CreateMap<Car, CarResponse>().ReverseMap();
            CreateMap<Car, CarRequest>().ReverseMap();
        }
    }
}
