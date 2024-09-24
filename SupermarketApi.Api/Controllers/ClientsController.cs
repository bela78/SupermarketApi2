using Microsoft.AspNetCore.Mvc;
using SupermarketApi.Contracts.Models;
using SupermarketApi.Core.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SupermarketApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("register-client")]
        public async Task<IActionResult> Post([FromBody] Client request)
        {
            var result = await _clientService.AddClient(request);
            if (result)
            {
                return Ok(new { Message = result });
            }

            return StatusCode(500, new { Message = "Ocurri� un error inesperado" });
        }

        [HttpGet("client/{name}")]
        public async Task<ActionResult> Get(string name)
        {
            var client = await _clientService.GetClientsAsync(name);
            if (client != null)
            {
                return Ok(client);
            }
            return NotFound(new { Message = "Cliente no encontrada" });

        }
        [HttpDelete("delete-client/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _clientService.DeleteClientById(id);
            if (result)
            {
                return Ok(new { Message = "Cliente eliminado correctamente" });
            }
            return NotFound(new { Message = "Cliente no encontrado para eliminar" });
        }
    }
}
