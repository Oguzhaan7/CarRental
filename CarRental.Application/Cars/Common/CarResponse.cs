using CarRental.Application.Rentals.Common;
using CarRental.Application.Reservations.Common;
using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Cars.Common
{
    public class CarResponse
    {
        public Guid Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public decimal DailyPrice { get; set; }
        public bool IsAvailable { get; set; }
        public FuelType FuelType { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public Color Color { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public List<RentalResponse> Rentals { get; set; } = new();
        public List<ReservationResponse> Reservations { get; set; } = new();
    }
}
