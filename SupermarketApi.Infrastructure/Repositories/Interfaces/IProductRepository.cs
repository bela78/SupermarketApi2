using SupermarketApi.Contracts.Models;
using SupermarketApi.Contracts.Utilities;

namespace SupermarketApi.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task<List<Product>> GetProduct(Category category);
    }
}
