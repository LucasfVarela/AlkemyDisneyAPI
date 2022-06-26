using API.CoreBusiness.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CoreBusiness.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaAlta { get; set; }
        public Role Role { get; set; }
    }
}
