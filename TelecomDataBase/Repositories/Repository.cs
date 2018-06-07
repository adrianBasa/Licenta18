using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelecomDataBase.Models;

namespace TelecomDataBase.Repositories
{
    public class Repository : IRepository
    {
        private AdminLoginEntities dbModel = new AdminLoginEntities();

        public void AddClient(Client client)
        {
            dbModel.Clients.Add(client);
            dbModel.SaveChanges();
        }

        public void DeleteClientById(int id)
        {
            var client = FindClientById(id);
            dbModel.Clients.Remove(client);
            dbModel.SaveChanges();
        }

        public Client FindClientById(int id)
        {
            var client = dbModel.Clients.Where(c => c.Id == id).FirstOrDefault();
            return client;
        }

        public IList<Client> GetAllClients()
        {
            return dbModel.Clients.ToList();
        }

        public void SetClietStateToModified(Client client)
        {
            dbModel.Entry(client).State = System.Data.Entity.EntityState.Modified;
            dbModel.SaveChanges();
        }
    }
}