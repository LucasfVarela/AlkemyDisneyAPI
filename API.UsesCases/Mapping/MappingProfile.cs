using API.CoreBusiness.Entity;
using API.CoreBusiness.Request;
using API.CoreBusiness.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.UsesCases.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequest, Usuario>();
            CreateMap<Usuario, UserResponse>();
            CreateMap<Personaje, PersonajeResponse>();
            CreateMap<PeliculaSerie, PeliculaResponse>();
        }
    }
}
