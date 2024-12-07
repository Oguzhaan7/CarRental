using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Invoices.Common
{
    public class InvoiceResponse
    {
        public Guid Id { get; set; }
        public Guid RentalId { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public decimal PaymentAmount { get; set; }
    }
}
