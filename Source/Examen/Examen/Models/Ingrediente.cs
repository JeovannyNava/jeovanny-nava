using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models
{
    public class Ingrediente
    {
        [Key]
        public int IdIngrediente { get; set; }
        public string Nombre { get; set; }
        public string Porcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int IdReceta { get; set; }
        [ForeignKey("IdReceta")]
        public virtual Receta Receta{ get; set; }
    }
}
