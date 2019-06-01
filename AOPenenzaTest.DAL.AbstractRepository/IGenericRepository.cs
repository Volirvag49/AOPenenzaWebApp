using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AOPenenzaTest.DAL.AbstractRepository
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsynс(int? id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
