using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Models.Cars;
using RestApi.Persistence;
using RestApi.Persistence.Repositories;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class MainController : ControllerBase
    {
        private ICarRepository _carRepository;
        private AppDbContext _context;

        public MainController(ICarRepository carRepository, AppDbContext context)
        {
            _carRepository = carRepository;
            _context = context;
        }
        
        [HttpGet("hello")]
        public async Task<IActionResult> Hello()
        {
            var res = await Task.Run(() => "Hi! I'm working");
            return Ok(res);
        }
        
        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            var model = new Model();
            model.Name = "Audi a4 tsfi";
            model.State = BaseState.Create;
            model.Description = "vw grp";
            
            var car = new Car();
            car.Mark = Mark.Honda;
            car.Model = model;
            car.Description = "test number One";
            car.State = BaseState.Create;
            car.Inspections = new List<Inspection>();
            
            
            
            _carRepository.Add(car);
            _carRepository.SaveChanges();
            var res = await Task.Run(() => _carRepository.GetAll());
            return Ok(res);
        }
        
        [HttpGet("cars")]
        public async Task<IActionResult> Cars()
        {
            var res = await Task.Run(() => _carRepository.GetAll());
            return Ok(res);
        }
    }
}