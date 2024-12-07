using CarRental.Application.Cars.Commands.CreateCar;
using CarRental.Application.Cars.Commands.DeleteCar;
using CarRental.Application.Cars.Commands.UpdateCar;
using CarRental.Application.Cars.Commands.UpdateCarAvailable;
using CarRental.Application.Cars.Common;
using CarRental.Application.Cars.Quieries.GetCarById;
using CarRental.Application.Cars.Quieries.GetCarsByFilters;
using CarRental.Application.Common.FilterExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [Route("car")]
    [ApiController]
    public class CarController : BaseApiController<CarController>
    {

        [HttpPost("createCar")]
        public async Task<IActionResult> CreateCar(CarRequest car)
        {
            var result = await _mediator.Send(new CreateCarCommand(car));

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("updateCar")]
        public async Task<IActionResult> UpdateCar(Guid id, CarRequest car)
        {
            var result = await _mediator.Send(new UpdateCarCommand(id, car));

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("deleteCar")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            var result = await _mediator.Send(new DeleteCarCommand(id));

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("getCarsByFilters")]
        public async Task<IActionResult> GetCarsByFilters(List<List<FilterValue>> filters)
        {
            var result = await _mediator.Send(new GetCarsByFiltersQuery(filters));

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getCarById")]
        public async Task<IActionResult> GetCarById(Guid id)
        {
            var result = await _mediator.Send(new GetCarByIdQuery(id));

            return Ok(result);
        }

        [HttpPut("updateCarAvailable")]
        public async Task<IActionResult> UpdateCarAvailable(UpdateCarAvailableCommand request)
        {
            var result = await _mediator.Send(request);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
