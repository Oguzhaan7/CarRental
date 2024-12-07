using CarRental.Application.Common.Responses;
using CarRental.Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Common.Validations
{
    public static class DateValidation
    {
        public static void ValidateDate(DateTime startDate, DateTime endDate)
        {
            if (startDate < DateTime.UtcNow.AddHours(1))
                throw new ArgumentException("The preparation time for the car is one hour");

            if (endDate < startDate || endDate.AddHours(-4) < startDate)
                throw new ArgumentException("The minimum rental duration should be four hours");      
        }

        public static bool IsDateRangeInside(DateRange outerRange, DateRange innerRange)
        {
            if ((innerRange.StartDate <= outerRange.StartDate && innerRange.EndDate >= outerRange.StartDate) || (innerRange.StartDate <= outerRange.EndDate && innerRange.EndDate >= outerRange.StartDate))
                return true;

            return false;
        }
    }

    public class DateRange
    {
        public DateRange(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
