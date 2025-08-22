using Microsoft.AspNetCore.Mvc;
using paddockCcell.Data;
using paddockCcell.DTO;


namespace paddockCcell.Controllers
{
    [Route("OrdemServico")]
    public class OrdemServicoController : Controller
    {
        private readonly AppDbContext _context;

        public OrdemServicoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("Buscar-Todas-OrdemServicos")]
        public IActionResult GetAll()
        {
            var ordens = _context.ordemServicos.ToList();
            return View(ordens);
        }

        [HttpGet("OrdemServico-Detalhes/{id}")]
        public IActionResult GetAllDetails(int id)
        {
            var ordem = _context.ordemServicos.Find(id);
            if (ordem == null)
                return NotFound();
            return View(ordem);
        }

        [HttpPost("Nova-OrdemServico")]
        public IActionResult Create([FromBody]OrdemServicoDTO ordemServicoDTO)
        {           
                _context.Update(ordemServicoDTO);
                _context.SaveChanges();
                return Ok(ordemServicoDTO);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var ordem = _context.ordemServicos.Find(id);
            if (ordem == null)
                return NotFound();
            _context.ordemServicos.Remove(ordem);
            _context.SaveChanges();
            return View(ordem);
        }
    }
}