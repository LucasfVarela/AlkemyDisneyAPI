using API.DataCore.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.UsesCases.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        IPersonajeRepository personajeRepository { get; }

        IPeliculaSerieRepository peliculaSerieRepository { get;  }

        IGeneroRepository generoRepository { get; }
        IUsuarioRepository UsuarioRepo { get;  }
        void Save();
    }
}
