using Car_oop.DTO;
using Car_oop.Models;

namespace Car_oop.Contracts
{
    public interface IClientsRepository
    {
        IEnumerable<ClientDto> GetAllClients(bool trackChanges);
        ClientDto GetClient(int id,bool trackChanges);

        //IEnumerable<Client> GetAllClients(bool trackChanges);
        //Client GetClient(int id,bool trackChanges);
    }
}
