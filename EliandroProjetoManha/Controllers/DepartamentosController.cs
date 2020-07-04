using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EliandroProjetoManha.Models;
using Microsoft.AspNetCore.Mvc;

namespace EliandroProjetoManha.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> list = new List<Departamento>();
            list.Add(new Departamento { Id = 1, Nome = "Alimentos" });
            list.Add(new Departamento { Id = 2, Nome = "Material escolar" });
            
            return View(list);
        }
    }
}
