using Examen.Core;
using Examen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Examen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetarioController : ControllerBase
    {
        private readonly DBContext _context;

        public RecetarioController(DBContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("getRecetas")]
        public List<Receta> getRecetas()
        {
          
            var postReceta = new SQLRecetario(_context);
            var responseReceta = postReceta.getRecetas();
            return responseReceta;
        }
        [HttpPost]
        [Route("postReceta")]
        public ResponseReceta postReceta(Receta receta)
        {
            ResponseReceta response = new ResponseReceta();
            var postReceta = new SQLRecetario(_context);
            var responseReceta = postReceta.PostReceta(receta);
            if (responseReceta)
            {
                response.CodeResponse = 200;
                return response;
            }
            else
            {
                response.CodeResponse = 500;
                return response;
            }
        }

        [HttpPut]
        [Route("postReceta")]
        public ResponseReceta putReceta(Receta receta)
        {
            ResponseReceta response = new ResponseReceta();
            var postReceta = new SQLRecetario(_context);
            var responseReceta = postReceta.UpdateReceta(receta);
            if (responseReceta)
            {
                response.CodeResponse = 200;
                return response;
            }
            else
            {
                response.CodeResponse = 500;
                return response;
            }
        }

        [HttpDelete]
        [Route("deleteReceta")]
        public ResponseReceta deleteReceta(int IdReceta)
        {
            ResponseReceta response = new ResponseReceta();
            var postReceta = new SQLRecetario(_context);
            var responseReceta = postReceta.deleteReceta(IdReceta);
            if (responseReceta)
            {
                response.CodeResponse = 200;
                return response;
            }
            else
            {
                response.CodeResponse = 500;
                return response;
            }
        }

        [HttpGet]
        [Route("getIngredientes")]
        public List<Ingrediente> getIngredientes()
        {
            List<Ingrediente> ingredientes = new List<Ingrediente>();

            ingredientes = _context.Ingredientes.ToList();
            return ingredientes;
        }


    }
}
