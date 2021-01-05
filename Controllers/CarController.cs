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
    [Route("api/cars")]
    public class CarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet("list")]
        public async Task<IActionResult> Cars()
        {
            var res = await Task.Run(() => _unitOfWork.CarRepository.GetAll());
            return Ok(res);
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
        
        [HttpGet("testCarsWithModels")]
        public async Task<IActionResult> CarsWithModels()
        {
            var cars = await Task.Run(() => _unitOfWork.CarRepository.GetAll(car => true, null, car => car.Model));
            return Ok(cars);
        }
        
        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            var model = new Model();
            model.Mark = Mark.Audi;
            model.Name = "Audi a4 tsfi";
            model.State = BaseState.Create;
            model.Description = "vw grp";
            
            var car = new Car();
            car.Mark = Mark.Audi;
            car.Model = model;
            car.Description = "test number One";
            car.State = BaseState.Create;
            car.Inspections = new List<Inspection>();
            car.Created = DateTime.Now;
            
            _unitOfWork.CarRepository.Add(car);
            _unitOfWork.CarRepository.SaveChanges();
            var res = await Task.Run(() => _unitOfWork.CarRepository.GetAll());
            return Ok(res);
        }
    }
}