using Car_oop.Interface;
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
        public IActionResult GetAllClients()
        {
            var models = _modelCarRepository.GetAllModels(trackChanges: false);
            return Ok(models);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetClient(int id)
        {
            var model = _modelCarRepository.GetModel(id, trackChanges: false);
            return Ok(model);
        }
    }
}
