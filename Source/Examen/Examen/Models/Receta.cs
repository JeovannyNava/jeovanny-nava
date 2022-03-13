using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models
{
    public class Receta
    {
        [Key]
        public int IdReceta { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string Imagen { get; set; }
        public virtual ICollection<Ingrediente> Ingredientes{ get; set; }

    }
}
