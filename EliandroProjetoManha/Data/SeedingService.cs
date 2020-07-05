using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EliandroProjetoManha.Models;
using EliandroProjetoManha.Models.Enums;

namespace EliandroProjetoManha.Data
{
    public class SeedingService
    {
        private EliandroProjetoManhaContext _context;

        public SeedingService(EliandroProjetoManhaContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departamento.Any() ||
                _context.Pedido.Any() ||
                _context.RegistroPedidos.Any())
            {
                return; // O Banco de dados ja foi populado
            }

            Departamento d1 = new Departamento(1, "Alimentos");
            Departamento d2 = new Departamento(2, "Materiais Escolares");
            Departamento d3 = new Departamento(3, "Eletronicos");
            Departamento d4 = new Departamento(4, "Cosmeticos");

            Pedido p1 = new Pedido(1, "Arroz", "Eliandro Silva", new DateTime(2020, 7, 22), 12.0, 2, d1);
            Pedido p2 = new Pedido(2, "Carne", "Felipe Augusto", new DateTime(2020, 7, 12), 12.0, 5, d1);
            Pedido p3 = new Pedido(3, "Caderno", "Andre dos Santos", new DateTime(2020, 7, 5), 32.0, 12, d2);
            Pedido p4 = new Pedido(4, "Livro", "Edmilson", new DateTime(2020, 5, 22), 8.0, 2, d2);
            Pedido p5 = new Pedido(5, "Teclado", "Jose Mande", new DateTime(2020, 8, 22), 98.0, 9, d3);
            Pedido p6 = new Pedido(6, "Creme", "Maria da Silva", new DateTime(2020, 7, 22), 12.0, 2, d4);
            Pedido p7 = new Pedido(7, "Baton", "Rafaela", new DateTime(2020, 8, 14), 132.0, 22, d4);

            RegistroPedidos r1 = new RegistroPedidos(1, new DateTime(2019, 07, 12), 122.0, StatusPedidos.Faturado, p1);
            RegistroPedidos r2 = new RegistroPedidos(2, new DateTime(2019, 01, 13), 12.0, StatusPedidos.Faturado, p1);
            RegistroPedidos r3 = new RegistroPedidos(3, new DateTime(2019, 04, 14), 52.0, StatusPedidos.Faturado, p2);
            RegistroPedidos r4 = new RegistroPedidos(4, new DateTime(2019, 01, 1), 72.0, StatusPedidos.Faturado, p2);
            RegistroPedidos r5 = new RegistroPedidos(5, new DateTime(2019, 06, 4), 222.0, StatusPedidos.Faturado, p3);
            RegistroPedidos r6 = new RegistroPedidos(6, new DateTime(2019, 02, 5), 56.0, StatusPedidos.Faturado, p3);
            RegistroPedidos r7 = new RegistroPedidos(7, new DateTime(2019, 06, 16), 89.0, StatusPedidos.Faturado, p4);
            RegistroPedidos r8 = new RegistroPedidos(8, new DateTime(2019, 06, 5), 87.0, StatusPedidos.Faturado, p5);
            RegistroPedidos r9 = new RegistroPedidos(9, new DateTime(2019, 02, 8), 7889.0, StatusPedidos.Faturado, p6);
            RegistroPedidos r10 = new RegistroPedidos(10, new DateTime(2019, 05, 9), 234.0, StatusPedidos.Faturado, p7);

            _context.Departamento.AddRange(d1, d2, d3, d4);
            _context.Pedido.AddRange(p1, p2, p3, p4, p5, p6, p7);
            _context.RegistroPedidos.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10);

            _context.SaveChanges();
        }
    }
}
