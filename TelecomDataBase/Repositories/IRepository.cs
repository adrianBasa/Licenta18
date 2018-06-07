using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelecomDataBase.Models;

namespace TelecomDataBase.Repositories
{
    public interface IRepository
    {
        Client FindClientById(int id);
        void DeleteClientById(int id);
        void SetClietStateToModified(Client client);
        void AddClient(Client client);
        IList<Client> GetAllClients();
    }
}
