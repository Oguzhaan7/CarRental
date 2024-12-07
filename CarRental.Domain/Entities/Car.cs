﻿using CarRental.Domain.Base;
using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class Car : BaseEntity, IEntity
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public decimal DailyPrice { get; set; }
        public bool IsAvailable { get; set; }
        public FuelType FuelType { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public Color Color { get; set; }

        public List<Rental> Rentals { get; set; } = new();
        public List<Reservation> Reservations { get; set; } = new();

    }
}