using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using paddockCcell.Models;

namespace paddockCcell.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Celular> celulares { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Orcamento> orcamentos { get; set; }
        public DbSet<OrdemServico> ordemServicos { get; set; }
        public DbSet<Servico> servicos { get; set; }
    }
}