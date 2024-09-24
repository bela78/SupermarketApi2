using SupermarketApi.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApi.Infrastructure.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task AddClient(Client client);
        Task<Client> GetClient(string name);
        Task<bool> DeleteProductById(string id);
    }
}
