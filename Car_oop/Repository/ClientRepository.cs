using AutoMapper;
using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Models;
using Car_oop.Models.Exception_custom;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Car_oop.Repository
{
    //public class ClientRepository : RepositoryBase<Client>, IClientsRepository
    //{
    //    public ClientRepository(RepositoryContext context) : base(context)
    //    {
    //    }

    //    public IEnumerable<Client> GetAllClients(bool trackChanges)
    //    {
    //        return FindAll(trackChanges).OrderBy(g =>g.Id).ToList();
    //    }

    //    public Client GetClient(int id, bool trackChanges)
    //    {
    //        return FindByCondition(c => c.Id == id, trackChanges).SingleOrDefault();
    //    }
    //}

    public class ClientRepository : RepositoryBase<Client>, IClientsRepository
    {
        private readonly IMapper _mapper;
        public ClientRepository(RepositoryContext context,IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public IEnumerable<ClientDto> GetAllClients(bool trackChanges)
        {
            //Использование Imapper
            var clients = FindAll(trackChanges).OrderBy(x => x.Id).ToList();
            //var clientsDto = clients.Select(x => new ClientDto(x.Id, string.Join(' ', x.name, x.surname), x.clientPhone, x.passport)).ToList();
            var clientsDto = _mapper.Map<IEnumerable <ClientDto>>(clients);
            return clientsDto;
        }

        public ClientDto GetClient(int id, bool trackChanges)
        {
            var clients = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();
            //Использование Imapper
            //var clientsDto = new ClientDto(clients.Id, string.Join(' ', clients.name, clients.surname), clients.clientPhone, clients.passport);
            var clientsDto = _mapper.Map<ClientDto>(clients);  
            return clientsDto;
        }
        public ClientDto CreateClient(ClientForCreationcs personal)
        {
            var clientEntity = _mapper.Map<Client>(personal);
            Create(clientEntity);
            var clientReturn = _mapper.Map<ClientDto>(clientEntity);
            return clientReturn;
        }
        public IEnumerable<ClientDto> GetByIds(IEnumerable<int> id,bool trackChanges) 
            {
            if(id == null)
            {
                throw new IdBadRequestException();
            }
            var ClientsEntity = FindByCondition(x => id.Contains(x.Id),trackChanges).ToList();

            if (id.Count() != ClientsEntity.Count())
            {
                throw new IdMisMatchRequest();
            }
            var clientReturn = _mapper.Map<IEnumerable<ClientDto>>(ClientsEntity);
            return clientReturn;
            }
        public (IEnumerable<ClientDto> clientDto, string ids) CreateClientCollection(
            IEnumerable<ClientForCreationcs> personalCollection)
        {
            if(personalCollection == null)
            {
                throw new ClientCollectionBadRequestExcaption();
            }
            var clientEntities = _mapper.Map<IEnumerable<Client>>(personalCollection);
            foreach(var client in clientEntities)
            {
                Create(client);
            }
            _context.SaveChanges();
            var clientReturn = _mapper.Map<IEnumerable<ClientDto>>(clientEntities);
            var ids = string.Join(",", clientReturn.Select(x => x.Id));
            return (clientDto: clientReturn, ids: ids);
        }   
    }

}
