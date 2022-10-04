using FoodBnD.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FoodBnD.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            //"Status409Conflict", is a security risk; a hacker can exploit it.
            DuplicateEmailException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage), 
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured")
        };
        return Problem(statusCode: statusCode, title : message);
    }
}

