using API.CoreBusiness.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.UsesCases.Services.PluginInterfaces
{
    public interface IPeliculaService
    {
        public IEnumerable<PeliculaResponse> Get();
       public IEnumerable<PeliculaResponse> GetFilter(string type, object filter);
    }
}
