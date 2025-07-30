using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using paddockCcell.Data;

namespace paddockCcell.Controllers
{
    [Route("/")]
    public class OrcamentoController : Controller
    {
        private readonly AppDbContext _context;

        public OrcamentoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            

            return Ok();
        }

       
    }
}