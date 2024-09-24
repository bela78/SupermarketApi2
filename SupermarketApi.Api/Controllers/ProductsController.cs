using Microsoft.AspNetCore.Mvc;
using SupermarketApi.Contracts.Models;
using SupermarketApi.Contracts.Utilities;
using SupermarketApi.Core.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SupermarketApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("register-product")]
        public async Task<IActionResult> Post([FromBody] Product request)
        {
            var result = await _productService.AddProduct(request);
            if (result)
            {
                return Ok(new { Message = result });
            }

            return StatusCode(500, new { Message = "Ocurri� un error inesperado" });
        }

        [HttpGet("product/{category}")]
        public async Task<ActionResult> Get(Category category)
        {
            var product = await _productService.GetProductAsync(category);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound(new { Message = "Producto no encontrado" });

        }
    }
}
