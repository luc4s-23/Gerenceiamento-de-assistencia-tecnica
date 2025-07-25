using System.ComponentModel.DataAnnotations;


namespace paddockCcell.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string? NomeCompleto { get; set; }
        public string? CPF { get; set; }
        public string? Telefone { get; set; }
    }
}