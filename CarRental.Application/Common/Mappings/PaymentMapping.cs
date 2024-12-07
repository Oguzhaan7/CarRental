using AutoMapper;
using CarRental.Application.Payments.Common;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Common.Mappings
{
    public class PaymentMapping : Profile
    {
        public PaymentMapping()
        {
            CreateMap<Payment, PaymentRequest>().ReverseMap();
            CreateMap<Payment, PaymentResponse>().ReverseMap();
        }
    }
}
