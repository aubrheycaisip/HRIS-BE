using HRIS_BE.Helpers.Interfaces;
using HRIS_BE.Helpers.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRIS_BE.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserInfoController : ControllerBase
    {
        private readonly IJwtService jwtService;

        public UserInfoController(IJwtService jwtService)
        {
            this.jwtService = jwtService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult UserLogin([FromBody] UserLogin username)
        {
            if(username.Username == "darwin")
            {
                return Ok(jwtService.GenerateJwtToken(username));
            }
            else
            {
                return BadRequest("invalid user");
            }
        }
    }
}
