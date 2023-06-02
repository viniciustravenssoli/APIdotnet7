using FirstAPIdotnet7.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPIdotnet7.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class Auth : ControllerBase
    {
        [HttpPost]

        public IActionResult Authenticate(string username, string password)
        {
            if (username == "usertest" && password == "passwordtest")
            {
                var token = TokenService.GenerateToken(new Domain.Model.Employee());
                return Ok(token);
            }

            return BadRequest("username or password dont match");
        }
    }
}
