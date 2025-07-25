using System.ComponentModel.DataAnnotations;

namespace paddockCcell.Models
{
    public class Celular
    {
        [Key]
        public int Id { get; set; }
        public string? Fabricante { get; set; }
        public string ?Linha { get; set; }
        public string? Tela { get; set; }
    }
}