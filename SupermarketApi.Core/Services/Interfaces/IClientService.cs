using SupermarketApi.Contracts.Models;

namespace SupermarketApi.Core.Services.Interfaces
{
    public interface IClientService
    {
        Task<bool> AddClient(Client request);
        Task<Client> GetClientsAsync(string name);
        Task<bool> DeleteClientById(string id);
    }
}
