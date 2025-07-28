using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using paddockCcell.Data;
using paddockCcell.DTO;

namespace paddockCcell.Controllers
{
    [Route("/")]
    public class ClienteController : Controller
    {
        private readonly AppDbContext _context;
        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("registrar-cliente")]
        public IActionResult Create([FromBody] ClienteDTO clienteDTO)
        {
            
            return Ok();
        }
    }
}