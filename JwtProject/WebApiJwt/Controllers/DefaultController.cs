using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        [HttpGet("[action]")]
        public IActionResult Test()
        {
            return Ok(new CreateToken().TokenCreate());
        }

        [HttpGet("[action]")]
        [Authorize]
        public IActionResult Test2()
        {
            return Ok("Hoşgeldin!");
        }
        [HttpGet("[action]")]
        public IActionResult Test4()
        {
            return Ok(new CreateToken().TokenCreateAdmin());
        }


        [HttpGet("[action]")]
        [Authorize(Roles ="Admin")]
        public IActionResult Test3()
        {
            return Ok("Hoşgeldin Admin!");
        }
    }
}
