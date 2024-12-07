using CarRental.Domain.Base;
using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class Reservation : BaseEntity, IEntity
    {
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ReservationExpireDate { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
    }
}
