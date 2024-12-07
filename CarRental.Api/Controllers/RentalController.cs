using CarRental.Application.Rentals.Commands.CreateRental;
using CarRental.Application.Rentals.Commands.DeleteRental;
using CarRental.Application.Rentals.Commands.UpdateRental;
using CarRental.Application.Rentals.Quieries.GetRentalById;
using CarRental.Application.Rentals.Quieries.GetRentalsByCarId;
using CarRental.Application.Rentals.Quieries.GetRentalsByUserId;
using CarRental.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [Route("rental")]
    [ApiController]
    public class RentalController : BaseApiController<RentalController>
    {
        [HttpPost("createRental")]
        public async Task<IActionResult> CreateRental(CreateRentalCommand request)
        {
            var result = await _mediator.Send(request);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("updateRental")]
        public async Task<IActionResult> UpdateRental(UpdateRentalCommand request)
        {
            var result = await _mediator.Send(request);

            if (result.Success)
                return Ok(result);
            
            return BadRequest(result);
        }

        [HttpDelete("deleteRental")]
        public async Task<IActionResult> DeleteRental(Guid id)
        {
            var result = await _mediator.Send(new DeleteRentalCommand(id));

            if (result.Success)
                return Ok(result);
            
            return NotFound(result);
        }

        [HttpGet("getRentalById")]
        public async Task<IActionResult> GetRentalById(Guid id)
        {
            var result = await _mediator.Send(new GetRentalByIdQuery(id));

            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpGet("getRentalsByCarId")]
        public async Task<IActionResult> GetRentalsByCarId(Guid id, int pageNumber, int pageSize)
        {
            var result = await _mediator.Send(new GetRentalsByCarIdQuery(id, pageNumber, pageSize));

            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpGet("getRentalsByUserId")]
        public async Task<IActionResult> GetRentalsByUserId(Guid id, int pageNumber, int pageSize)
        {
            var result = await _mediator.Send(new GetRentalsByUserIdQuery(id, pageNumber, pageSize));

            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

    }
}
