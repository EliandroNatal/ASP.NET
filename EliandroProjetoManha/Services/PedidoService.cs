using EliandroProjetoManha.Data;
using EliandroProjetoManha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EliandroProjetoManha.Services.Exceptions;

namespace EliandroProjetoManha.Services
{
    public class PedidoService
    {
        private readonly EliandroProjetoManhaContext _context;

        public PedidoService(EliandroProjetoManhaContext context)
        {
            _context = context;
        }

        public List<Pedido> FindAll()
        {
            return _context.Pedido.ToList();
        }

        public void Insert(Pedido obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Pedido FindById(int produtoId)
        {
            return _context.Pedido.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.ProdutoId == produtoId);
        }

        public void Remove(int produtoId)
        {
            var obj = _context.Pedido.Find(produtoId);
            _context.Pedido.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Pedido obj)
        {
            if(!_context.Pedido.Any(x => x.ProdutoId == obj.ProdutoId))
            {
                throw new NotFoundException("Id do produto nao encontrado"); 
            }
            try { 
            _context.Update(obj);
            _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
