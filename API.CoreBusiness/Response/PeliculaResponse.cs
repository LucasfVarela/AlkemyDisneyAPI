using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CoreBusiness.Response
{
    public class PeliculaResponse
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string? Img { get; set; }
    }
}
