using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EliandroProjetoManha.Models;
using EliandroProjetoManha.Models.ViewModels;
using EliandroProjetoManha.Services;
using EliandroProjetoManha.Services.Exceptions;
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

        public IActionResult Delete(int? produtoId)
        {
            if (produtoId == null)
            {
                return NotFound();
            }

            var obj = _pedidoService.FindById(produtoId.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int produtoId)
        {
            _pedidoService.Remove(produtoId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? produtoId)
        {
            if (produtoId == null)
            {
                return NotFound();
            }

            var obj = _pedidoService.FindById(produtoId.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Edit(int? produtoId)
        {
            if (produtoId == null)
            {
                return NotFound();
            }

            var obj = _pedidoService.FindById(produtoId.Value);
            if(obj == null)
            {
                return NotFound();
            }

            List<Departamento> departamentos = _departamentoService.FindAll();
            PedidoFormViewModel viewModel = new PedidoFormViewModel { Pedido = obj, Departamentos = departamentos };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int produtoId, Pedido pedido)
        {
            if (produtoId != pedido.ProdutoId)
            {
                return BadRequest();
            }
            try { 
            _pedidoService.Update(pedido);
            return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}