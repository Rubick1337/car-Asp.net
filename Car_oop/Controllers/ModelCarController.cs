using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Car_oop.Controllers
{
    [ApiController]
    [Route("api/modelcar")]
    public class ModelCarController : ControllerBase
    {
        private readonly IModelCarRepository _modelCarRepository;

        public ModelCarController(IModelCarRepository modelCarRepository)
        {
            _modelCarRepository = modelCarRepository;
        }
        [HttpGet]
        public IActionResult GetAllModelCar()
        {
            var models = _modelCarRepository.GetAllModels(trackChanges: false);
            return Ok(models);
        }
        [HttpGet("{id:int}", Name = "GetModelCar")]
        public IActionResult GetModelCar(int id)
        {
            var model = _modelCarRepository.GetModel(id, trackChanges: false);
            return Ok(model);
        }
        [HttpPost]
        public IActionResult CreateModelCar([FromBody] ModelCarCreationDto model)
        {
            if(model == null)
                return BadRequest("Model is null");
            var modelReturn = _modelCarRepository.CreateModelCar(model);
            return Ok(modelReturn);
        }
        [HttpDelete("{id:int}")]
        public NoContentResult DeleteModelCar(int id)
        {
            _modelCarRepository.DeleteModelCar(id, trackChanges: false);
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateModelCar(int id, [FromBody] ModelCarForUpdateDto modelCar)
        {
            if (modelCar == null)
            {
                return BadRequest("modelCar is null");
            }
            _modelCarRepository.UpdateModelCar(id, modelCar, trackChanges: true);
            return NoContent();

        }
    }
}
