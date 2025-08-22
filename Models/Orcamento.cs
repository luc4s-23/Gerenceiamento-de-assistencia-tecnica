using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace paddockCcell.Models
{
    public class Orcamento
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Servico")]
        public int Id_Servico_FK { get; set; }
        public decimal ValorTotal { get; set; }
        public string? CondicaoPagamento { get; set; }
    }
}