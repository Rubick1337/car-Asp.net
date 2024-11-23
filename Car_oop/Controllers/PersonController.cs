using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Car_oop.Controllers
{
    [ApiController]
    [Route("api/personal")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonalRepository _personalRepository;

        public PersonController(IPersonalRepository personalRepository)
        {
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
            var personCreate = _personalRepository.CreatePersonal(personal,PostId,false);
            return Ok(personCreate);
        }
        [HttpDelete("{id:int}")]
        public NoContentResult DeletePerson(int id) { 
            _personalRepository.DeletePersonal(id, trackChanges: false);
            return NoContent();
        }

    }
}
