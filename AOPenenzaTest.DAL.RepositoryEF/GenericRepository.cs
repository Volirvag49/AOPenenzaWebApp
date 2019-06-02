using AOPenenzaTest.DAL.AbstractRepository;
using AOPenenzaTest.DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AOPenenzaTest.DAL.RepositoryEF
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        protected ApplicationDBContext dbContext;
        protected DbSet<T> dbSet;

        public GenericRepository(ApplicationDBContext context)
        {
            dbContext = context;
            dbSet = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsynс(int? id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> where = null)
        {
            return await dbSet.CountAsync(where);
        }

        public async Task<decimal> AverageAsync(Expression<Func<T, decimal>> where = null)
        {
            return await dbSet.AverageAsync(where);
        }

        public void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
