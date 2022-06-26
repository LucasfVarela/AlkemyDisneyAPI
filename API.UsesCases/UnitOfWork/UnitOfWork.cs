using API.CoreBusiness;
using API.CoreBusiness.DataContext;
using API.DataCore.PluginInterfaces;
using API.DataCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.UsesCases.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IPersonajeRepository personajeRepository { get; private set; }

        public IPeliculaSerieRepository peliculaSerieRepository { get; private set; }

        public IGeneroRepository generoRepository { get; private set; }
        public IUsuarioRepository UsuarioRepo { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            personajeRepository = new PersonajeRepository(context);
            peliculaSerieRepository = new PeliculaSerieRepository(context);
            generoRepository = new GeneroRepository(context);
            UsuarioRepo = new UsuarioRepository(context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
