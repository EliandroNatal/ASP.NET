using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EliandroProjetoManha.Models;

namespace EliandroProjetoManha.Data
{
    public class EliandroProjetoManhaContext : DbContext
    {
        public EliandroProjetoManhaContext (DbContextOptions<EliandroProjetoManhaContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<RegistroPedidos> RegistroPedidos { get; set; }
    }
}
