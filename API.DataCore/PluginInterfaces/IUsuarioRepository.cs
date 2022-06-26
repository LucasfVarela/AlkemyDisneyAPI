using API.CoreBusiness.Entity;
using API.GenericCore.GenericRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataCore.PluginInterfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Usuario GetByEmail(string email);
        bool ExisteUsuario(string email);
    }
}
