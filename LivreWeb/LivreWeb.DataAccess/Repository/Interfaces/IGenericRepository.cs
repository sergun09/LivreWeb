using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LivreWeb.DataAccess.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class 
    {
        // Implémentation des méthodes communes à toutes les repositories
        Task<IEnumerable<T>> GetAll();
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        void DeleteOne(T entity);
        void DeleteFromTo(IEnumerable<T> entities);
    }
}
