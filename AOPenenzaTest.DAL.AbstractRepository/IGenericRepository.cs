using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AOPenenzaTest.DAL.AbstractRepository
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsynс(int? id);
        Task<int> CountAsync(Expression<Func<T, bool>> where = null);

        Task<decimal> AverageAsync(Expression<Func<T, decimal>> where = null);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
