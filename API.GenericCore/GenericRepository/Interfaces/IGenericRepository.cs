using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace API.GenericCore.GenericRepository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> find(Expression<Func<T,bool>> predicate);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int? id);
        T GetById(int? id);
        

    }
}
