using CarRental.Application.Users.Commands.RegisterUser;
using CarRental.Application.Users.Commands.UpdatePassword;
using CarRental.Application.Users.Quieries.GetUser;
using CarRental.Application.Users.Quieries.Login;
using CarRental.Application.Users.Quieries.ValidateToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : BaseApiController<UserController>
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand request)
        {
            var result = await _mediator.Send(request);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            var result = await _mediator.Send(query);

            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }
        [Authorize]
        [HttpGet("getUser")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var result = await _mediator.Send(new GetUserQuery(id));

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPut("updatePassword")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordCommand request)
        {
            var result = await _mediator.Send(request);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet("validateToken")]
        public async Task<IActionResult> ValidateToken(string token)
        {
            var result = await _mediator.Send(new ValidateTokenQuery(token));

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
