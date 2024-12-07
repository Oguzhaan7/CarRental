using CarRental.Domain.Base;
using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class Rental : BaseEntity, IEntity
    {
        public Guid UserId { get; set; }      
        public Guid CarId { get; set; }      
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public InsuranceType InsuranceType { get; set; }
        public Invoice Invoice { get; set; } = new();
        public List<Payment> Payments { get; set; } = new();
    }
}
