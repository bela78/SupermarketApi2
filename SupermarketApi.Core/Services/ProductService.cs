using SupermarketApi.Contracts.Models;
using SupermarketApi.Contracts.Utilities;
using SupermarketApi.Core.Services.Interfaces;
using SupermarketApi.Infrastructure.Repositories.Interfaces;

namespace SupermarketApi.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> AddProduct(Product request)
        {
            var product = new Product
            {
                Name = request.Name,
                Prize = request.Prize,
                Categoria = request.Categoria
            };
            await _productRepository.AddProduct(product);
            return true;
        }

        public async Task<List<Product>> GetProductAsync(Category category)
        {
            return await _productRepository.GetProduct(category);
        }
    }
}
