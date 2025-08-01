using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using paddockCcell.Data;
using paddockCcell.DTO;
using paddockCcell.Models;

namespace paddockCcell.Controllers
{
    [Route("/")]
    public class ClienteController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ClienteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpPost("registrar-cliente")]
        public IActionResult Create([FromBody] ClienteDTO clienteDTO)
        {
            var NovoCliente = new Cliente
            {
                NomeCompleto = clienteDTO.NomeCompleto,
                CPF = clienteDTO.CPF,
                Telefone = clienteDTO.Telefone
            };
            _context.clientes.Add(NovoCliente);
            _context.SaveChanges();
            return Ok(NovoCliente);
        }

        [HttpGet("buscar-cliente-por-id{id}")]
        public IActionResult GetClienteId(int id)
        {
            var Cliente = _context.clientes.FirstOrDefault(c => c.Id == id);
            if (Cliente == null)
                return NotFound("Nenhum cliente encontrado");
            return Ok(Cliente);
        }

        [HttpGet("buscar-clientes")]
        public IActionResult GetAllCliente()
        {
            var Clientes = _context.clientes.ToList();
            return Ok(Clientes);
        }

        [HttpPatch("atualizar-cliente{idCliente}")]
        public IActionResult Updateliente([FromRoute] int idCliente, [FromBody] ClienteDTO clienteDTO)
        {
            var clienteExistente = _context.clientes.FirstOrDefault(c => c.Id == idCliente);
            if (clienteExistente == null) return NotFound("Cliente não encontrado");

            _mapper.Map(clienteDTO, clienteExistente);

            _context.SaveChanges();
            return Ok(clienteExistente);
        }

        [HttpDelete("deletar-cliente{id}")]
        public IActionResult Deletar(int id)
        {
            var Cliente = _context.clientes.FirstOrDefault(c => c.Id == id);
            if (Cliente == null)
                return NotFound("Cliente não encontrado");
            _context.clientes.Remove(Cliente);
            _context.SaveChanges();
            return Ok(Cliente);
        }
    }
}