using EliandroProjetoManha.Data;
using EliandroProjetoManha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EliandroProjetoManha.Services
{
    public class DepartamentoService
    {
        private readonly EliandroProjetoManhaContext _context;

        public DepartamentoService(EliandroProjetoManhaContext context)
        {
            _context = context;
        }

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }
    }
}
