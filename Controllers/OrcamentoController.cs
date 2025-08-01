using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using paddockCcell.Data;
using paddockCcell.DTO;
using paddockCcell.Models;

namespace paddockCcell.Controllers
{
    [Route("/")]
    public class OrcamentoController : Controller
    {
        private readonly AppDbContext _context;

        public OrcamentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("novo-orcamento")]
        public IActionResult Create([FromBody] OrcamentoDTO orcamentoDTO, [FromBody] List<Servico> servicos)
        {
            decimal ValorServicos = 0.00m;
            if (servicos == null)
                return NotFound("Nenhum serviço registrado para este orçamento");    

            foreach (var item in servicos)
                {
                    ValorServicos = item.ValorServico += item.ValorServico;
                }
            var Orcamento = new Orcamento
            {
                ListaServicos = servicos,
                ValorTotal = ValorServicos,
                CondicaoPagamento = orcamentoDTO.CondicaoPagamento
            };
            _context.orcamentos.Add(Orcamento);
            _context.SaveChanges();
            return Ok(Orcamento);
        }

       
    }
}