using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SupermarketApi.Contracts.Models;
using SupermarketApi.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApi.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IMongoCollection<Client> _clients;

        public ClientRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("Supermarket");
            _clients = database.GetCollection<Client>("Clients");
        }

        public async Task AddClient(Client client)
        {
            try
            {
                await _clients.InsertOneAsync(client);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar el cliente: {ex.Message}");
                throw;
            }
        }

        public async Task<Client> GetClient(string name)
        {

            return await _clients.Find<Client>(c => c.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteProductById(string id)
        {
            var result = await _clients.DeleteOneAsync(c => c.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
