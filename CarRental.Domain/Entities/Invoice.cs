using CarRental.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class Invoice : BaseEntity, IEntity
    {
        public Guid RentalId { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty; 
        public decimal PaymentAmount { get; set; }
    }
}
