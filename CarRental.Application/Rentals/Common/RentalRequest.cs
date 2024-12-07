using CarRental.Application.Payments.Common;
using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Rentals.Common
{
    public class RentalRequest
    {
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public InsuranceType InsuranceType { get; set; }
        public List<PaymentRequest> PaymentRequest { get; set; } = new();
    }
}
