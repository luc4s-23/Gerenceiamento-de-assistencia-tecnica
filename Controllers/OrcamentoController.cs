// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using paddockCcell.Data;
// using paddockCcell.DTO;
// using paddockCcell.Models;

// namespace paddockCcell.Controllers
// {
//     [Route("/")]
//     public class OrcamentoController : Controller
//     {
//         private readonly AppDbContext _context;
//         private readonly Servico servico;

//         public OrcamentoController(AppDbContext context)
//         {
//             _context = context;
//         }

//         [HttpPost("novo-orcamento")]
//         public IActionResult Create([FromBody] List<OrcamentoDTO> orcamentoDTOs)
//         {

//             if (orcamentoDTOs == null || !orcamentoDTOs.Any()) return NotFound("Nenhum serviço registrado para este orçamento");

//             foreach (var item in orcamentoDTOs)
//             {
//                 //decimal ValorServicos;
//                 //var s = _context.servicos.FirstOrDefault(o => o.Id == item.Id_Servico_FK);
//                 if (_context.servicos.FirstOrDefault(o => o.Id == item.Id_Servico_FK) != null)
//                 {
//                     var Orcamento = new Orcamento
//                     {
//                         Id_Servico_FK = item.Id_Servico_FK,
//                        // ValorServico = item.ValorServico,
//                         CondicaoPagamento = item.CondicaoPagamento
//                     };
//                     _context.orcamentos.Add(Orcamento);
//                 }

//             }
//             _context.SaveChanges();
//             return Ok();
//         }

//         // [HttpPost("request-orcamento")]
//         // public IActionResult Request([FromBody] OrcamentoRequestDTO request)
//         // {
//         //     if (request == null || request.ServicoIds == null || !request.ServicoIds.Any())
//         //         return BadRequest("Serviços não informados.");

//         //     decimal valorTotal = 0m;
//         //     var servicos = _context.servicos
//         //         .Where(s => request.ServicoIds.Contains(s.Id))
//         //         .ToList();

//         //     if (servicos.Count != request.ServicoIds.Count)
//         //         return NotFound("Um ou mais serviços não encontrados.");

//         //     foreach (var servico in servicos)
//         //     {
//         //         valorTotal += servico.ValorServico;
//         //     }

//         //     var orcamento = new Orcamento
//         //     {
//         //         ValorTotal = valorTotal,
//         //         CondicaoPagamento = request.CondicaoPagamento
//         //     };

//         //     _context.orcamentos.Add(orcamento);
//         //     _context.SaveChanges();

//         //     return Ok(new { OrcamentoId = orcamento.Id, ValorTotal = valorTotal });
//         // }

//     }
// }