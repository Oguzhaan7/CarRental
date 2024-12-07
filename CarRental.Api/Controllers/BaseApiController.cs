using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public abstract class BaseApiController<T> : ControllerBase
    {
        private ISender mediator;
        protected ISender _mediator => mediator ??= HttpContext.RequestServices.GetService<ISender>();
        protected string email { get => HttpContext.User.Claims.Where(x => x.Type.Contains("email")).FirstOrDefault().Value; }
    }
}
