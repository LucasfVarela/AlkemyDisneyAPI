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
    public class PeliculaService : IPeliculaService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        List<PeliculaSerie> peliculaSeries = new List<PeliculaSerie>();

        public PeliculaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<PeliculaResponse> Get()
        {
            List<PeliculaSerie> peliculaSeriesList = unitOfWork.peliculaSerieRepository.GetAll().ToList();
            return mapper.Map<List<PeliculaResponse>>(peliculaSeriesList);
        }
        public IEnumerable<PeliculaResponse> GetFilter(string type,dynamic filter) =>
            type switch
            { 
                null => throw new ArgumentNullException(nameof(type)),
                "name" =>GetByName(filter),
                "genre"=>GetByGenre(filter),
                "asc"=>GetByAsc(filter),
                "desc"=>GetByDesc(filter),
            };

        private IEnumerable<PeliculaResponse> GetByName(dynamic filter)
        {
            string nombre = filter.ToString();
            peliculaSeries = unitOfWork.peliculaSerieRepository.find(b => b.Nombre == nombre).ToList();
            return mapper.Map<List<PeliculaResponse>>(peliculaSeries);
        }
        private IEnumerable<PeliculaResponse> GetByAsc(dynamic filter)
            =>(List<PeliculaResponse>)Get().OrderBy(x =>x.ReleaseDate);

        private IEnumerable<PeliculaResponse>GetByDesc(dynamic filter)
        {
           return (List<PeliculaResponse>)Get().OrderBy(x =>x.ReleaseDate);
        }
           

        private IEnumerable<PeliculaResponse> GetByGenre(dynamic filter)
        {
            int idGenero = (int)filter; 
            peliculaSeries = (from p in (unitOfWork.peliculaSerieRepository.GetAll())
                                           where p.generos.Where(x => x.Id == idGenero).Count() > 0
                                           select p).ToList();
            return mapper.Map<List<PeliculaResponse>>(peliculaSeries);
            
            
        }
    }
}
