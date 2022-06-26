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
     public class PeliculaSerieRepository : GenericRepository<PeliculaSerie>, IPeliculaSerieRepository
    {
        public PeliculaSerieRepository(ApplicationDbContext options): base(options)
        {

        }
    }
}
