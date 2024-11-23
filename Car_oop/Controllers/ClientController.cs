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
        [HttpGet("{id:int}", Name = "GetClient")]
        public IActionResult GetClient(int id)
        {
            var clients = _clientsRepository.GetClient(id, trackChanges: false);
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
        [HttpGet("collection/({ids})", Name = "GetCollectionCleint")]
        public IActionResult GetCollectionCleint(string ids)
        {
            var idList = ids.Split(',').Select(int.Parse).ToList();
            var clients = _clientsRepository.GetByIds(idList, trackChanges: false);
            return Ok(clients);
        }
        [HttpPost("collection")]
        public IActionResult CreateCollectionClients([FromBody] IEnumerable<ClientForCreationcs> clientCollection)
        {
            var result = _clientsRepository.CreateClientCollection(clientCollection);
            return CreatedAtRoute("GetCollectionCleint", new { result.ids }, result.clientDto);
        }
        [HttpDelete("{id:int}")]
        public NoContentResult DeleteClient(int id)
        {
            _clientsRepository.DeleteClient(id, trackChanges: false);
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateClient(int id, [FromBody] ClientForUpdateDto client)
        {
            if (client == null) 
                return BadRequest("Client is null");
            _clientsRepository.UpdateClient(id,trackChanges: true, client);
            return NoContent();
        }
    }

}
