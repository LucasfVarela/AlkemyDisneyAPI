using API.CoreBusiness.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.UsesCases.Services.PluginInterfaces
{
    public interface IPersonajeService
    {
      public  IEnumerable<PersonajeResponse> Get();
      public  IEnumerable<PersonajeResponse> GetFilter(string type, object filter);
    }
}
