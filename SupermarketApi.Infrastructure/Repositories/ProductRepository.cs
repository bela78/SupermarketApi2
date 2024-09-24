using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SupermarketApi.Contracts.Models;
using SupermarketApi.Contracts.Utilities;
using SupermarketApi.Infrastructure.Repositories.Interfaces;

namespace SupermarketApi.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("Supermarket");
            _products = database.GetCollection<Product>("Products");
        }

        public async Task AddProduct(Product product)
        {
            try
            {
                await _products.InsertOneAsync(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar el producto: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Product>> GetProduct(Category category)
        {

            return await _products.Find<Product>(cat => cat.Categoria == category).ToListAsync();
        }
    }
}
