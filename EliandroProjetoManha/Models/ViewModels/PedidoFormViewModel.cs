using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EliandroProjetoManha.Models.ViewModels
{
    public class PedidoFormViewModel
    {
        public Pedido Pedido { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
