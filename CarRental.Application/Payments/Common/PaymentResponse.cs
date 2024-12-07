using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Payments.Common
{
    public class PaymentResponse
    {
        public Guid Id { get; set; }
        public Guid RentalId { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
