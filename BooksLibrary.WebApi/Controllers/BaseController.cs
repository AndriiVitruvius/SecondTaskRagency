using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

using Microsoft.AspNetCore.Http;

namespace BooksLibrary.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected   IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        

    }
}
