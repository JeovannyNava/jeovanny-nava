using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Examen.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly DBContext _context;

        public AdministradorController(DBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var recetas = new RecetarioController(_context);
            var model = recetas.getRecetas();
            return View(model);
           
        }

        public IActionResult Receta(int IdReceta)
        {
            
            var receta = _context.Recetas.FirstOrDefault(x=> x.IdReceta == IdReceta)?? new Receta();
            var ingredientes = IdReceta !=0 ? _context.Ingredientes.Where(x => x.IdReceta == IdReceta).ToList() : new List<Ingrediente>();
            ViewBag.Ingredientes = JsonConvert.SerializeObject(ingredientes.Select(z => new { z.Nombre, z.Porcion }).ToList());
            ViewBag.IdReceta = IdReceta;
            ViewBag.Imagen = receta?.Imagen?? string.Empty;
            return View(receta);
        }

        public JsonResult SubirNuevaReceta(Receta receta)
        {
            var recetarioController = new RecetarioController(_context);
            var post = receta.IdReceta==0? recetarioController.postReceta(receta): recetarioController.putReceta(receta);

            if (post.CodeResponse == 200)
            {
                return Json(new { response = "Ok" });
            }
            else
            {
                return Json(new { response = "fail" });
            }
            
        }

        public IActionResult Editar(int IdReceta)
        {
            var receta = _context.Recetas.Find(IdReceta);
            return View(receta);
        }

        public JsonResult EliminarReceta(int IdReceta)
        {
            var recetarioController = new RecetarioController(_context);
            var post = recetarioController.deleteReceta(IdReceta);
            return Json(new { response = "Ok"});
        }
    }
}
