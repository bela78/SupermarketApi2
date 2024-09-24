using SupermarketApi.Contracts.Models;
using SupermarketApi.Core.Services.Interfaces;
using SupermarketApi.Infrastructure.Repositories.Interfaces;

namespace SupermarketApi.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<bool> AddClient(Client request)
        {
            var client = new Client
            {
                Name = request.Name,
                Document = request.Document,
                Phone = request.Phone
            };

            await _clientRepository.AddClient(client);
            return true;
        }

        public async Task<Client> GetClientsAsync(string name)
        {
            return await _clientRepository.GetClient(name);

        }
        public async Task<bool> DeleteClientById(string id)
        {
            return await _clientRepository.DeleteProductById(id);
        }
    }
}
