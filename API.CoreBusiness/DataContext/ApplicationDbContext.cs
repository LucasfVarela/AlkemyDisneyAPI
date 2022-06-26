using API.CoreBusiness.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CoreBusiness.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
       public DbSet<Usuario> Usuario { get; set; }
       public  DbSet<Personaje> Personaje { get; set; }
       public DbSet<Genero> Genero { get; set; }  
       public DbSet<PeliculaSerie> PeliculaSerie { get; set; }    

    }
}
