using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace paddockCcell.Models
{
    public class OrdemServico
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Servico")]
        public int Id_Servico { get; set; }

        [ForeignKey("Cliente")]
        public int Id_Cliente { get; set; }
    }
}