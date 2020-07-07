using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EliandroProjetoManha.Models;
using EliandroProjetoManha.Models.ViewModels;
using EliandroProjetoManha.Services;
using Microsoft.AspNetCore.Mvc;

namespace EliandroProjetoManha.Controllers
{
    public class PedidosController : Controller
    {
        private readonly PedidoService _pedidoService;
        private readonly DepartamentoService _departamentoService;

        public PedidosController(PedidoService pedidoService, DepartamentoService departamentoService)
        {
            _pedidoService = pedidoService;
            _departamentoService = departamentoService;
        }
        public IActionResult Index()
        {
            var list = _pedidoService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departamentos = _departamentoService.FindAll();
            var viewModel = new PedidoFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pedido pedido)
        {
            _pedidoService.Insert(pedido);
            return RedirectToAction(nameof(Index));
        }
    }
}