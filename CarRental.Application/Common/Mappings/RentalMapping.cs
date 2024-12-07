using AutoMapper;
using CarRental.Application.Common.Responses;
using CarRental.Application.Rentals.Common;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Common.Mappings
{
    public class RentalMapping : Profile
    {
        public RentalMapping()
        {
            CreateMap<Rental, RentalResponse>().ReverseMap();
            CreateMap<Rental, RentalRequest>().ReverseMap();
            CreateMap<PagedResponse<Rental>, PagedResponse<RentalResponse>>().ReverseMap();
        }
    }
}
