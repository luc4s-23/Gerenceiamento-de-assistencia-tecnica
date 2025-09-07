using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using paddockCcell.Data;
using paddockCcell.DTO;
using paddockCcell.Models;

namespace paddockCcell.Controllers
{
    [Route("")]
    public class ServicoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ServicoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("novo-servico")]
        public IActionResult Create([FromBody]ServicoDTO servicoDTO)
        {
            if (servicoDTO == null) return BadRequest("Dados inválidos");

            var NovoServico = new Servico
            {
                NomeServico = servicoDTO.NomeServico,
                ValorServico = servicoDTO.ValorServico
            };

            _context.servicos.Add(NovoServico);
            _context.SaveChanges();
            return Ok(NovoServico);
        }

        [HttpGet("listar-todos-servicos")]
        public IActionResult GetAll()
        {
            var servicos = _context.servicos.ToList();
            if (servicos == null || !servicos.Any()) return NotFound("Nenhum serviços registrado");
            return Ok(servicos);
        }
        [HttpGet("buscar-por-id{id}")]
        public IActionResult GetId(int id)
        {
            var servico = _context.servicos.Find(id);
            if (servico == null) return NotFound("Serviço não encontrado");
            return Ok(servico);
        }

        [HttpDelete("deletar-servico{id}")]
        public IActionResult Deletar(int id)
        {
            var servicoDeletar = _context.servicos.Find(id);

            if (servicoDeletar == null)
                return NotFound();

            _context.servicos.Remove(servicoDeletar);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPatch("atualizar-servico{id}")]
        public IActionResult Update(int id, [FromBody] ServicoDTO servicoDTO)
        {
            if (servicoDTO == null) return BadRequest("Dados inválidos");

            var servico = _context.servicos.FirstOrDefault(s => s.Id == id);
            if (servico == null) return NotFound("Serviço não encontrado");

            _mapper.Map(servicoDTO, servico);
            _context.SaveChanges();
            return Ok(servico);
        }
    }
}