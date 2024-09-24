using SupermarketApi.Contracts.Models;
using SupermarketApi.Contracts.Utilities;

namespace SupermarketApi.Core.Services.Interfaces
{
    public interface IProductService
    {
        Task<bool> AddProduct(Product request);
        Task<List<Product>> GetProductAsync(Category category);
    }
}
