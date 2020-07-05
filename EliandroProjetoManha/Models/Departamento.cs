using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace EliandroProjetoManha.Models
{
    public class Departamento
    {
        [Key]
        public int PedidoId { get; set; }
        public string Nome { get; set; }
        public ICollection<Pedido> Solicitacoes { get; set; } = new List<Pedido>();

        public Departamento()
        {
        }

        public Departamento(int pedidoId, string nome)
        {
            PedidoId = pedidoId;
            Nome = nome;
        }

        public void AddPedido(Pedido pedido)
        {
            Solicitacoes.Add(pedido);
        }

        public double TotalPedidos(DateTime initial, DateTime final)
        {
            return Solicitacoes.Sum(pedido => pedido.TotalPedidos(initial, final));
        }
    }
}
