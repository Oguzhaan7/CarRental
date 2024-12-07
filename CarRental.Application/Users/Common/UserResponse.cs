using CarRental.Application.Rentals.Common;
using CarRental.Application.Reservations.Common;
using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Users.Common
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.User;
        public List<RentalResponse> Rentals { get; set; } = new();
        public List<ReservationResponse> Reservations { get; set; } = new();
        public string? Token { get; set; } = string.Empty;
    }
}
