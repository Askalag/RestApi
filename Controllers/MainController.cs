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
        
        [HttpGet("cars")]
        public async Task<IActionResult> Cars()
        {
            var res = await Task.Run(() => _unitOfWork.CarRepository.GetAll());
            return Ok(res);
        }
        
        [HttpGet("carsWithModels")]
        public async Task<IActionResult> CarsWithModels()
        {
            var cars = await Task.Run(() => _unitOfWork.CarRepository.GetAll(car => true, null, car => car.Model));
            return Ok(cars);
        }

        [HttpPost("addCar")]
        public async Task<IActionResult> AddCar([FromBody] Car car)
        {
            Console.Write("test");
            _unitOfWork.CarRepository.Add(car);
            _unitOfWork.CarRepository.SaveChanges();
            await Task.CompletedTask;
            return Ok("ok");
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
            
            _unitOfWork.CarRepository.Add(car);
            _unitOfWork.CarRepository.SaveChanges();
            var res = await Task.Run(() => _unitOfWork.CarRepository.GetAll());
            return Ok(res);
        }
    }
}