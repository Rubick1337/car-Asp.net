using Car_oop.DTO;
using Car_oop.Models;

namespace Car_oop.Contracts
{
    public interface IClientsRepository
    {
        IEnumerable<ClientDto> GetAllClients(bool trackChanges);
        ClientDto GetClient(int id, bool trackChanges);

        //IEnumerable<Client> GetAllClients(bool trackChanges);
        //Client GetClient(int id,bool trackChanges);
        ClientDto CreateClient(ClientForCreationcs personal);
        IEnumerable<ClientDto> GetByIds(IEnumerable<int> ids, bool trackChanges);
        (IEnumerable<ClientDto> clientDto, string ids) CreateClientCollection(
            IEnumerable<ClientForCreationcs> personal);
        void DeleteClient(int Id, bool trackChanges);
        void UpdateClient(int id, bool trackChanges, ClientForUpdateDto updateClient);
    }
}
