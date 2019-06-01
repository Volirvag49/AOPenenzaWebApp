using AOPenenzaTest.DAL.AbstractRepository;
using AOPenenzaTest.DAL.EF;
using System;
using System.Threading.Tasks;

namespace AOPenenzaTest.DAL.RepositoryEF
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext dbContext;

        public UnitOfWork(string connectionString)
        {
            dbContext = new ApplicationDBContext(connectionString);
        }

        public UnitOfWork(ApplicationDBContext context)
        {
            dbContext = context;
        }

        public async Task<int> CommitAsync()
        {
            return await dbContext.SaveChangesAsync();
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
