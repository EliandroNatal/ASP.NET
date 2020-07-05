﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EliandroProjetoManha.Services;
using Microsoft.AspNetCore.Mvc;

namespace EliandroProjetoManha.Controllers
{
    public class PedidosController : Controller
    {
        private readonly PedidoService _pedidoService;

        public PedidosController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }
        public IActionResult Index()
        {
            var list = _pedidoService.FindAll();
            return View(list);
        }
    }
}
