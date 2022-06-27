using API.CoreBusiness.Entity;
using API.UsesCases.Services.PluginInterfaces;
using API.UsesCases.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisneyAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private readonly IPersonajeService personajeService;
        private readonly IUnitOfWork unitOfWork;

        public PersonajesController(IPersonajeService personajeService, IUnitOfWork unitOfWork)
        {
            this.personajeService = personajeService;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Personaje>> GetFilter([FromQuery] string? name, [FromQuery] int? age, [FromQuery] int? movie)
        {
            return (name, age, movie) switch
            {
                (not null, null, null) => Ok(personajeService.GetFilter("name",name)),
                (null, not null, null) => Ok(personajeService.GetFilter("age",age)),
                (null, null, not null) => Ok(personajeService.GetFilter("movie", movie)),
                _ => Ok(personajeService.Get()),
            };
        }
        [HttpGet("{id}")]
        public ActionResult<Personaje> GetCharacter(int id)
        {
            if (unitOfWork.personajeRepository is null || 
                    (unitOfWork.personajeRepository.GetAllPersonajes(id)is null)) 
                            return NotFound();
             return unitOfWork.personajeRepository.GetAllPersonajes(id);
            
        }
        [HttpPut("{id}")]
        public IActionResult PutCharacter(int id, Personaje personaje)
        {
            if (id != personaje.Id) return BadRequest();
            unitOfWork.personajeRepository.Update(personaje);
            unitOfWork.Save();
            return NoContent();
        }


        [HttpPost]
        public ActionResult<Personaje> PostCharacter(Personaje personaje)
        {
            if (unitOfWork.personajeRepository is null) return BadRequest();
            unitOfWork.personajeRepository.Insert(personaje);
            unitOfWork.Save();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCharacter(int id)
        {
            if (unitOfWork.personajeRepository.GetById(id) is null) return NotFound();
            unitOfWork.personajeRepository.Delete(id);
            unitOfWork.Save();
            return NoContent();
        }

    }
}
