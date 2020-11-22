using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class MainController : ControllerBase
    {
        [HttpGet("hello")]
        public async Task<IActionResult> Hello()
        {
            var res = await Task.Run(() => "Hi! I'm working");
            return Ok(res);
        }
    }
}