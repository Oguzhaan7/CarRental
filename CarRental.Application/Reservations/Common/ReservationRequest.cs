using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Reservations.Common
{
    public record ReservationRequest(Guid UserId, Guid CarId, DateTime StartDate, DateTime EndDate);
}
