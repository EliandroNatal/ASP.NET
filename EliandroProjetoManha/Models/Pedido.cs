using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EliandroProjetoManha.Models
{
    public class Pedido
    {
        [Key]
        public int ProdutoId { get; set; }
       [Required(ErrorMessage ="Campo Obrigatorio")]
        public string Produto { get; set; }
        public string Fornecedor { get; set; }
        public DateTime Data { get; set; }
        [Required]
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<RegistroPedidos> Pedidos { get; set; } = new List<RegistroPedidos>();

        public Pedido()
        {
        }

        public Pedido(int produtoId, string produto, string fornecedor, DateTime data, double valor, int quantidade, Departamento departamento)
        {
            ProdutoId = produtoId;
            Produto = produto;
            Fornecedor = fornecedor;
            Data = data;
            Valor = valor;
            Quantidade = quantidade;
            Departamento = departamento;
        }

        public void AddPedidos(RegistroPedidos sr)
        {
            Pedidos.Add(sr);
        }

        public void RemoverPedidos(RegistroPedidos sr)
        {
            Pedidos.Remove(sr);
        }

        public double TotalPedidos(DateTime initial, DateTime final)
        {
            return Pedidos.Where(sr => sr.Horario >= initial && sr.Horario <= final).Sum(sr => sr.Quantia);
        }
    }
}
