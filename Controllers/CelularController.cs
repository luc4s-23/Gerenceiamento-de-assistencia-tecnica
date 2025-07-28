using Microsoft.AspNetCore.Mvc;
using paddockCcell.Data;
using paddockCcell.DTO;
using paddockCcell.Models;

namespace paddockCcell.Controllers
{
    [Route("/")]
    public class CelularController : Controller
    {
        private readonly AppDbContext _context;
        public CelularController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("novo-celular")]
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


        [HttpDelete("deletar-celular{idCelular}")]
        public IActionResult Delete(int idCelular)
        {
            var celularDeletar = _context.celulares.Find(idCelular);
            if (celularDeletar == null)
                return NotFound("Nenhum registro encontrado");

            _context.celulares.Remove(celularDeletar);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("listar-todos")]
        public IActionResult ListAll()
        {
            var Celulares = _context.celulares.ToList();
            if (Celulares == null)
                return NotFound("Nenhum registro encontrado");

            return Ok(Celulares);
        }

        //Os dois métodos abaixo foram usados apenas para alterações rápidas no banco de dados. 
        // Os mesmos não devem ser necessários em uso do dia a dia do software
        [HttpPost("registro-em-massa")]
        public IActionResult CreateNews([FromBody] List<CelularDTO> celularesDTO)
        {
            //Este foi usado para registrar uma quantidade relativa de itens de uma só vez para que pudesse facilitar nos testes
            if (celularesDTO == null)
                return NotFound("Lista de celulares inválida");
            foreach (var item in celularesDTO)
            {
                var celular = new Celular
                {
                    Fabricante = item.Fabricante,
                    Linha = item.Linha,
                    Tela = item.Tela

                };
                _context.celulares.Add(celular);
            }
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("Deletar-Todos")]
        public IActionResult DeletarAll()
        {
            //Este foi usado para apagar e recomeçar novos testes de inserção e delete
            List<Celular> DeletarCelulares = _context.celulares.ToList();

            _context.celulares.RemoveRange(DeletarCelulares);
            _context.SaveChanges();
            return Ok();
        }
    }
}