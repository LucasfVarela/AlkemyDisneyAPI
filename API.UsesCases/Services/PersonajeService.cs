using API.CoreBusiness.Entity;
using API.CoreBusiness.Response;
using API.UsesCases.Services.PluginInterfaces;
using API.UsesCases.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.UsesCases.Services
{
    public class PersonajeService : IPersonajeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        List<Personaje> personaje = new List<Personaje>();

        public PersonajeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;

        }

        public IEnumerable<PersonajeResponse> Get()
        {
            List<Personaje> personaje = unitOfWork.personajeRepository.GetAll().ToList();
            return  mapper.Map<List<PersonajeResponse>>(personaje);
        }

        public IEnumerable<PersonajeResponse> GetFilter(string type, dynamic filter) =>
        type switch
            {
                
                "name" => GetByName(filter),
                "age" => GetByEdad(filter),
                "movie" => GetByPelicula(filter),
                _ => throw new ArgumentNullException(nameof(type)),
            };
        
        private IEnumerable<PersonajeResponse> GetByName(dynamic filter)
        {
            string nombre = filter.ToString();
            personaje = unitOfWork.personajeRepository.find(b => b.Nombre == nombre).ToList();
            return mapper.Map<List<PersonajeResponse>>(personaje);
        }

        private IEnumerable<PersonajeResponse> GetByEdad(dynamic filter)
        {
            string edad =filter.ToString();
            personaje = unitOfWork.personajeRepository.find(b =>b.Edad == edad).ToList();
            return mapper.Map<List<PersonajeResponse>>(personaje);
        } 
        private IEnumerable<PersonajeResponse> GetByPelicula(dynamic filter)
        {
            
            int idMovie = (int)filter;
             personaje = (from p in (unitOfWork.personajeRepository.GetAll())
                         where p.peliculaSeries.Where(x => x.Id == idMovie).Count() > 0
                         select p).ToList();
            
            return mapper.Map<List<PersonajeResponse>>(personaje);
        }
    }

}

