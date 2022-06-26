using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CoreBusiness.Entity
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string? Img { get; set; }
        public ICollection<PeliculaSerie> peliculaSeries {get; set; }

    }
}
