using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace paddockCcell.DTO
{
    public class OrdemServicoDTO
    {
        public int Id_Servico { get; set; }
        public int Id_Cliente { get; set; }
        public string? DadosEquipamento { get; set; }
        public string? DescricaoProblema { get; set; }
        public string? Status { get; set; }

    }
}