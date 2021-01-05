using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Models.Cars;
using RestApi.Persistence;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/main")]
    public class MainController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MainController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet("hello")]
        public async Task<IActionResult> Hello()
        {
            var res = await Task.Run(() => "Hi! I'm working");
            return Ok(res);
        }
    }
}