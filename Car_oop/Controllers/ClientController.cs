using Car_oop.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Car_oop.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientsRepository _clientsRepository;

        public ClientController(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }
        [HttpGet]
        public IActionResult GetAllClients()
        {
            var clients = _clientsRepository.GetAllClients(trackChanges: false);
            return Ok(clients);
        }
        [HttpGet("{id:int}")]   
        public IActionResult GetClient(int id)
        {
            var clients = _clientsRepository.GetClient(id,trackChanges: false);
            return Ok(clients);
        }
    }

}
