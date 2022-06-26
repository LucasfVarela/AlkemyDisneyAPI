using API.CoreBusiness.Request;
using API.CoreBusiness.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.UsesCases.Services.PluginInterfaces
{
    public interface IUserService
    {
        UserResponse Registrar(UserRequest usuario, string password);
        UserResponse Login(string email, string password);
        string GetToken(UserResponse usuario);
    }
}
