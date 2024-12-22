using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models;
using Car_oop.Models.Exception_custom;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Car_oop.Controllers
{
    [ApiController]
    [Route("api/personal")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonalRepository _personalRepository;
        private readonly IValidator<PersonalForCreationDto> _postPersonValidator;
        private readonly IValidator<PersonalForUpdateDto> _putPersonValidator;

        public PersonController(IPersonalRepository personalRepository, IValidator<PersonalForCreationDto> postPersonValidator,
            IValidator<PersonalForUpdateDto> putPersonValidator)
        {
            _postPersonValidator = postPersonValidator;
            _putPersonValidator = putPersonValidator;
            _personalRepository = personalRepository;
        }
        [HttpGet]
        public IActionResult GetAllPersonal()
        {
            var personal = _personalRepository.GetAllPersonal(trackChanges: false);
            return Ok(personal);
        }
        [HttpGet("{id:int}",Name ="GetPersonal")]
        public IActionResult GetPersonal(int id)
        {
            var personal = _personalRepository.GetPersonal(id, trackChanges: false);
            return Ok(personal);
        }
        [HttpPost]
        public IActionResult CreatePersonal([FromBody] PersonalForCreationDto personal,int PostId)
        {
            if (personal == null)
                return BadRequest("Personal is null");
            FluentValidation.Results.ValidationResult result = _postPersonValidator.Validate(personal);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return UnprocessableEntity(ModelState);

            }
            var personCreate = _personalRepository.CreatePersonal(personal,PostId,false);
            return Ok(personCreate);
        }
        [HttpDelete("{id:int}")]
        public NoContentResult DeletePerson(int id) { 
            _personalRepository.DeletePersonal(id, trackChanges: false);
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdatePersonal(int id, int?PostId,[FromBody] PersonalForUpdateDto personal)
        {
            if(personal == null)
            {
                return BadRequest("person is null");
            }

            FluentValidation.Results.ValidationResult result = _putPersonValidator.Validate(personal);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return UnprocessableEntity(ModelState);

            }

            _personalRepository.UpdatePersonal(id, personal,PostId, trackChanges:true);
            return NoContent();

        }

    }
}
