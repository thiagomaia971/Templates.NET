using System;
using BaseApplication.Domain;
using BaseApplication.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BaseApplication.ApiApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        public IMediator Mediator => (IMediator) HttpContext.RequestServices.GetService(typeof(IMediator));
        
        public IActionResult SendCommandRequest<T>(ICommand<T> command) 
            => HandleResult(Mediator.Send(command).GetAwaiter().GetResult());

        protected IActionResult HandleResult<T>(CommandResult<T> result)
        {
            if (!result.IsSuccess)
                return BadRequestMessage(result?.Exception);
            return CreatedMessage(result);
        }

        protected IActionResult BadRequestMessage<T>(T result)
        {
            if (result is Exception exception)
                return BadRequest(exception);
            if (result is ModelStateDictionary modelState)
                return BadRequest(modelState);

            return BadRequest(result);
        }

        protected IActionResult CreatedMessage<T>(T result)
            => Ok(result);

        protected IActionResult CreatedMessage()
            => Ok();
    }
}