using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace _1_Cliente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult GetClientes([FromQuery] string nome, [FromQuery] string codigo)
        {
            var clientes = _clienteService.BuscarClientes(nome, codigo);
            return Ok(clientes);
        }
        [HttpGet("/todos")]
        public IActionResult GetAllClientes()
        {
            var clientes = _clienteService.BuscarTodosClientes();
            return Ok(clientes);
        }

        [HttpPost]
        public IActionResult CreateCliente([FromBody] Cliente cliente)
        {
            _clienteService.Criar(cliente);
            return Ok();
        }
    }

}
