using Car_oop.Contracts;
using Car_oop.Interface;
using Car_oop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Car_oop.Controllers
{
    [ApiController]
    [Route("api/car")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        [HttpGet]
        public IActionResult GetAllCar()
        {
            var cars = _carRepository.GetAllCars(trackChanges: false);
            return Ok(cars);
        }
        [HttpGet("{id:int}", Name = "GetCar")]
        public IActionResult GetCar(int id)
        {
            var cars = _carRepository.GetCar(id, trackChanges: false);
            return Ok(cars);
        }
    }
}
