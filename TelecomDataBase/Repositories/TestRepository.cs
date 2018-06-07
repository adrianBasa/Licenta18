using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelecomDataBase.Models;

namespace TelecomDataBase.Repositories
{
    public class TestRepository : IRepository
    {
        public IList<Client> Clients;

        public TestRepository(IList<Client> clients)
        {
            Clients = clients;
        }

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public void DeleteClientById(int id)
        {
            Clients.Remove(Clients.Where(c => c.Id == id).FirstOrDefault());
        }

        public Client FindClientById(int id)
        {
            return Clients.Where(c => c.Id == id).FirstOrDefault();
        }

        public IList<Client> GetAllClients()
        {
            throw new NotImplementedException();
        }

        public void SetClietStateToModified(Client client)
        {
            throw new NotImplementedException();
        }
    }
}