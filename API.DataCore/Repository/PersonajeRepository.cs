using API.CoreBusiness.DataContext;
using API.CoreBusiness.Entity;
using API.DataCore.PluginInterfaces;
using API.GenericCore.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataCore.Repository
{
    public class PersonajeRepository : GenericRepository<Personaje> , IPersonajeRepository
    {
        private readonly ApplicationDbContext options; 
        public PersonajeRepository(ApplicationDbContext options) : base(options) 
        {
            this.options = options;
        }
        public Personaje GetAllPersonajes(int id) =>
             options.Personaje.Where(x => x.Id == id)/*.Include(y => y.peliculaSeries)*/.FirstOrDefault();
        

    }
}
