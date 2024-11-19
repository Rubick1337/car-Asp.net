using Car_oop.Contracts;
using Car_oop.DTO;
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
        [HttpGet("{id:int}",Name = "GetClient")]   
        public IActionResult GetClient(int id)
        {
            var clients = _clientsRepository.GetClient(id,trackChanges: false);
            return Ok(clients);
        }
        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientForCreationcs client)
        {
            if (client == null)
                return BadRequest("Personal is null");
            var clientCreate = _clientsRepository.CreateClient(client);
            return Ok(clientCreate);
        }
    }

}
