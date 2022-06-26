using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CoreBusiness.Entity
{
    public class Personaje
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Edad { get; set; }
        public string? Imagen { get; set; }
        public double Peso { get; set; }
        public string? Historia { get; set; }
        public IEnumerable<PeliculaSerie>? peliculaSeries { get; set; }


    }
    
}
