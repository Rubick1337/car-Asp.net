﻿using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
        public ClientRepository(RepositoryContext context) : base(context)
        {
        }
        public IEnumerable<ClientDto> GetAllClients(bool trackChanges)
        {
            var clients = FindAll(trackChanges).OrderBy(x => x.Id).ToList();
            var clientsDto = clients.Select(x => new ClientDto(x.Id, string.Join(' ', x.name, x.surname), x.clientPhone, x.passport)).ToList();
            return clientsDto;
        }

        public ClientDto GetClient(int id, bool trackChanges)
        {
            var clients = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();

            var clientsDto = new ClientDto(clients.Id, string.Join(' ', clients.name, clients.surname), clients.clientPhone, clients.passport);
            return clientsDto;
        }
    }

}
