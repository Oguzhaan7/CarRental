using AutoMapper;
using CarRental.Application.Invoices.Common;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Common.Mappings
{
    public class InvoiceMapping : Profile
    {
        public InvoiceMapping()
        {
            CreateMap<Invoice, InvoiceResponse>().ReverseMap();
        }
    }
}
