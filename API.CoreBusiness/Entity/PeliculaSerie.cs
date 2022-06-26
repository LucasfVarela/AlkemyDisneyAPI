using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CoreBusiness.Entity
{
    public class PeliculaSerie
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Imagen { get; set; }
        public DateTime Estreno { get; set; }
        [Range(1,5)]
        public int Calificacion { get; set; }
        public IEnumerable<Personaje>? personajes { get; set; }
        public IEnumerable<Genero>? generos { get; set; }
    }
}
