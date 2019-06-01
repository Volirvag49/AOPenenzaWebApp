using AOPenenzaTest.DAL.EF.Entities;
using System;
using System.Threading.Tasks;

namespace AOPenenzaTest.DAL.AbstractRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<DbEmployee> Employees { get; }

        Task<int> CommitAsync();
    }
}
