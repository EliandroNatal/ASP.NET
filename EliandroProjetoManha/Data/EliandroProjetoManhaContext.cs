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

        public DbSet<EliandroProjetoManha.Models.Departamento> Departamento { get; set; }
    }
}
