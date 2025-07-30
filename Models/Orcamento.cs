using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace paddockCcell.Models
{
    public class Orcamento
    {
        [Key]
        public int Id { get; set; }
        public List<Servico>? ListaServicos { get; set; }
        public decimal ValorTotal { get; set; }
        public string? CondicaoPagamento { get; set; }
    }
}