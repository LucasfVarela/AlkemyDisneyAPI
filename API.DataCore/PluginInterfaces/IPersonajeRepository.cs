using API.CoreBusiness.Entity;
using API.CoreBusiness.Response;
using API.GenericCore.GenericRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataCore.PluginInterfaces
{
    public interface IPersonajeRepository : IGenericRepository<Personaje>
    {
        Personaje GetAllPersonajes(int id);
    }
}
