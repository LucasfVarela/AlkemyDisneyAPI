using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.CoreBusiness.DataContext;
using API.CoreBusiness.Entity;
using API.DataCore.PluginInterfaces;
using API.GenericCore.GenericRepository;
namespace API.DataCore.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext options): base(options)
        {

        }
        public Usuario GetByEmail(string email)
        {
            return context.Usuario.FirstOrDefault(a => a.Email == email);
        }
        public bool ExisteUsuario(string email)
        {
            return context.Usuario.Any(a => a.Email == email);
        }
    }
}
