using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Controllers
{
    public class HomeController : Controller
    {

        private readonly DBContext _context;

        public HomeController(DBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var recetas = new RecetarioController(_context);
            var model = recetas.getRecetas();
            model.ForEach(receta=>{
                receta.Ingredientes = _context.Ingredientes.Where(x => x.IdReceta == receta.IdReceta).ToList();
            });
            var ultimaReceta = model.OrderByDescending(x => x.IdReceta).FirstOrDefault()?? new Receta();
            ViewBag.UltimaReceta = ultimaReceta;
            return View(model);
            
        }
    }
}
