using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models.Exception_custom;
using Car_oop.Models;
using Car_oop.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Car_oop.Controllers
{
    [ApiController]
    [Route("api/modelcar")]
    public class ModelCarController : ControllerBase
    {
        private readonly IModelCarRepository _modelCarRepository;
        private readonly IValidator<ModelCarCreationDto> _postModelValidator;
        private readonly IValidator<ModelCarForUpdateDto> _putModelValidator;

        public ModelCarController(IModelCarRepository modelCarRepository, IValidator<ModelCarForUpdateDto> putModelValidator
            , IValidator<ModelCarCreationDto> postModelValidator)
        {
            _modelCarRepository = modelCarRepository;
            _postModelValidator = postModelValidator;
            _putModelValidator = putModelValidator;
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

            FluentValidation.Results.ValidationResult result = _postModelValidator.Validate(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return UnprocessableEntity(ModelState);

            }

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

            FluentValidation.Results.ValidationResult result = _putModelValidator.Validate(modelCar);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return UnprocessableEntity(ModelState);

            }

            _modelCarRepository.UpdateModelCar(id, modelCar, trackChanges: true);
            return NoContent();

        }
    }
}
