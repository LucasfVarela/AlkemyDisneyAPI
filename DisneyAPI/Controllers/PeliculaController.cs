using API.CoreBusiness.Entity;
using API.UsesCases.Services.PluginInterfaces;
using API.UsesCases.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisneyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPeliculaService peliculaService;
        public PeliculaController(IUnitOfWork unitOfWork, IPeliculaService peliculaService)
        {
            this.unitOfWork = unitOfWork;
            this.peliculaService = peliculaService; 
        }


        [HttpGet]
        public ActionResult<IEnumerable<PeliculaSerie>> Get([FromQuery] string? name, [FromQuery] string? order, [FromQuery] int? genre)
        {
            return (name, order, genre) switch
            {
                (not null, null, null) => Ok(peliculaService.GetFilter("name", name)),
                (null, "asc", null) => Ok(peliculaService.GetFilter("asc", order)),
                (null, "desc", null) => Ok(peliculaService.GetFilter("desc", order)),
                (null, null, not null) => Ok(peliculaService.GetFilter("genre", genre)),
                _ => Ok(peliculaService.Get()),
            };
        }

        
        [HttpGet("{id}")]
        public ActionResult<PeliculaSerie> GetMovie(int id)
        {
            if (unitOfWork.peliculaSerieRepository is null || (unitOfWork.peliculaSerieRepository.GetById(id))is null)            
                return NotFound();
            return unitOfWork.peliculaSerieRepository.GetById(id);
        }

        
        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, PeliculaSerie pelicula)
        {
            if (id != pelicula.Id)return BadRequest();
            unitOfWork.peliculaSerieRepository.Update(pelicula);
            unitOfWork.Save();
            return NoContent();
        }

        
        [HttpPost]
        public ActionResult<PeliculaSerie> PostMovie(PeliculaSerie pelicula)
        {
            if (unitOfWork.peliculaSerieRepository is null) return BadRequest();
            unitOfWork.peliculaSerieRepository.Insert(pelicula);
            unitOfWork.Save();
            return Ok();
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            if (unitOfWork.peliculaSerieRepository.GetById(id) is null) return NotFound();   
            unitOfWork.peliculaSerieRepository.Delete(id);
            unitOfWork.Save();
            return NoContent();
        }

    }
}


