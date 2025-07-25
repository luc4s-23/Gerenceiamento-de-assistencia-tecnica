using System.ComponentModel.DataAnnotations;

namespace paddockCcell.Models
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }
        public string? NomeServico { get; set; }
        public decimal ValorServico { get; set; }
    }
}