using LivreWeb.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LivreWeb.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LivreContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository(LivreContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await this._dbSet.AddAsync(entity);
        }

        public void DeleteFromTo(IEnumerable<T> entities)
        {
            this._dbSet.RemoveRange(entities);
        }

        public void DeleteOne(T entity)
        {
            this._dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this._dbSet.ToListAsync();
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await this._dbSet.FirstOrDefaultAsync(predicate);
        }
    }
}
