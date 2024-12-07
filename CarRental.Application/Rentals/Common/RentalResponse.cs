using CarRental.Application.Cars.Common;
using CarRental.Application.Invoices.Common;
using CarRental.Application.Payments.Common;
using CarRental.Application.Users.Common;
using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Rentals.Common
{
    public class RentalResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public InvoiceResponse Invoice { get; set; }
        public List<PaymentResponse> Payments { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public InsuranceType InsuranceType { get; set; }
    }
}
