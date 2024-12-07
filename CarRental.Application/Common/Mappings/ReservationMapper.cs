using AutoMapper;
using CarRental.Application.Reservations.Common;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Common.Mappings
{
    public class ReservationMapper : Profile
    {
        public ReservationMapper()
        {
            CreateMap<Reservation, ReservationResponse>().ReverseMap();
            CreateMap<Reservation, ReservationRequest>().ReverseMap();
        }
    }
}
