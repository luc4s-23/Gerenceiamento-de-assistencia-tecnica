using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using paddockCcell.Models;

namespace paddockCcell.DTO
{
    public class OrcamentoDTO
    {
        public List<Servico>? ListaServicos { get; set; }
        public decimal ValorTotal { get; set; }
        public string? CondicaoPagamento { get; set; }
    }
}