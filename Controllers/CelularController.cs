using Microsoft.AspNetCore.Mvc;
using paddockCcell.Data;
using paddockCcell.DTO;
using paddockCcell.Models;

namespace paddockCcell.Controllers
{
    [Route("[controller]")]
    public class CelularController : Controller
    {
        private readonly AppDbContext _context;
        public CelularController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("novno-celular")]
        public IActionResult Create([FromBody] CelularDTO celularDTO)
        {
            if (celularDTO == null)
                return BadRequest("Registro incorreto e/ou com falta de informações");

            var celular = new Celular
            {
                Fabricante = celularDTO.Fabricante,
                Linha = celularDTO.Linha,
                Tela = celularDTO.Tela
            };
            _context.celulares.Add(celular);
            _context.SaveChanges();
            return Ok(celular);
        }
    }
}