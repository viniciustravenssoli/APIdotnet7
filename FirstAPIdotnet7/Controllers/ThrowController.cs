using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPIdotnet7.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ThrowController : ControllerBase
    {
        [Route("/error")]

        public IActionResult HandleError() =>
            Problem();

        [Route("/error-development")]

        public IActionResult HandleErrorDevelopment(
        [FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var execptionHandleFeature = HttpContext.Features.Get<
                IExceptionHandlerFeature>()!;

            return Problem(
                detail: execptionHandleFeature.Error.StackTrace,
                title: execptionHandleFeature.Error.Message
                );
        }
    }
}
