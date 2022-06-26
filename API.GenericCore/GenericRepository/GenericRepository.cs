using API.CoreBusiness.DataContext;
using API.GenericCore.GenericRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace API.GenericCore.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Insert(T entity){
            context.Set<T>().Add(entity);
        }
        public void Update(T entity){ 
            context.Set<T>().Update(entity); 
        }
        public void Delete(int? id){
            context.Set<T>().Remove(GetById(id));
         }
        
        public T GetById(int? id) => context.Set<T>().Find(id);
        public IEnumerable<T> find(Expression<Func<T, bool>> predicate) => context.Set<T>().Where(predicate);
        public IEnumerable<T> GetAll() => context.Set<T>().ToList(); 
    }
}
