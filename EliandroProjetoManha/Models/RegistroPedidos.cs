using EliandroProjetoManha.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EliandroProjetoManha.Models
{
    public class RegistroPedidos
    {
        [Key]
        public int PedidoId { get; set; }
        public DateTime Horario { get; set; }
        public double Quantia { get; set; }
        public StatusPedidos Status { get; set; }
        public Pedido Pedido { get; set; }

        public RegistroPedidos()
        {
        }

        public RegistroPedidos(int pedidoId, DateTime horario, double quantia, StatusPedidos status, Pedido pedido)
        {
            PedidoId = pedidoId;
            Horario = horario;
            Quantia = quantia;
            Status = status;
            Pedido = pedido;
        }
    }
}
