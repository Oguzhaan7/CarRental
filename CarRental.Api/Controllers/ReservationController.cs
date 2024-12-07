using CarRental.Application.Reservations.Commands.CreateReservation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [Route("reservation")]
    [ApiController]
    public class ReservationController : BaseApiController<ReservationController>
    {
        [HttpPost("createReservation")]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand request)
        {
            var result = await _mediator.Send(request);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
