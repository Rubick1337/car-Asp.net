using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models;
using Car_oop.Models.Exception_custom;
using Car_oop.Repository;
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
        [HttpPost]
        public IActionResult CreateCar(int CarModelId)
        {
            if (CarModelId == null)
                return BadRequest("CarModelId is null");

            var clientCreate = _carRepository.CreateCar(CarModelId,false);
            return Ok(clientCreate);
        }
        [HttpDelete("{id:int}")]
        public NoContentResult DeleteCar(int id)
        {
            _carRepository.DeleteCar(id, trackChanges: false);
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateCar(int id, int CarModelId)
        {
            if (CarModelId == null)
                return BadRequest("CarModelId is null");

            _carRepository.UpdateCar(id, trackChanges: true, CarModelId);
            return NoContent();
        }
    }
}
