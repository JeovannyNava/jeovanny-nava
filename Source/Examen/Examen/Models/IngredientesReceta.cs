using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models
{
    public class IngredientesReceta
    {
        [Key]
        public int IdIngredienteReceta { get; set; }
        public int IdReceta { get; set; }
        [ForeignKey("IdReceta")]
        public virtual Receta Receta { get; set; }

        public int IdIngrediente { get; set; }
        [ForeignKey("IdIngrediente")]
        public virtual Ingrediente Ingrediente{ get; set; }
        public string Porcion { get; set; }
    }
}
