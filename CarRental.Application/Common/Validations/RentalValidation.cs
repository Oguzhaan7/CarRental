using CarRental.Application.Rentals.Commands.CreateRental;
using CarRental.Application.Rentals.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Common.Validations
{
    public class RentalValidation : AbstractValidator<CreateRentalCommand>
    {
        public RentalValidation()
        {
            RuleFor(x => x.Rental.StartDate).LessThan(x => x.Rental.EndDate).WithMessage("Başlangıç tarihi küçük olmalı");
            RuleFor(x => x.Rental.StartDate).GreaterThan(x => DateTime.UtcNow).WithMessage("Başlangıç tarihi şimdiden büyük olmalı");
        }
    }
}
