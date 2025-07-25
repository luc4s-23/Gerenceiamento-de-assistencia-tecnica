using paddockCcell.Data;
using paddockCcell.DTO;
using paddockCcell.Models;

namespace paddockCcell.Services
{
    public class CelularService
    {
        private readonly AppDbContext _context;

        public CelularService(AppDbContext context)
        {
            _context = context;
        }

        // public Celular Registrar(CelularDTO celularDTO)
        // {
        //     var celular = new Celular
        //     {
        //         Fabricante = celularDTO.Fabricante,
        //         Linha = celularDTO.Linha,
        //         Tela = celularDTO.Tela
        //     };

        // }
    }
}