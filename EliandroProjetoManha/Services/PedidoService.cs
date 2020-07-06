﻿using EliandroProjetoManha.Data;
using EliandroProjetoManha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            obj.Departamento = _context.Departamento.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
