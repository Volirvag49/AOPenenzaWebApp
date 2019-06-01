using AOPenenzaTest.DAL.AbstractRepository;
using AOPenenzaTest.DAL.EF.Entities;

namespace AOPenenzaTest.DAL.RepositoryEF
{
    public partial class UnitOfWork
    {
        private IGenericRepository<DbEmployee> employeeRepository;

        public IGenericRepository<DbEmployee> Employees
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new GenericRepository<DbEmployee>(dbContext);
                }
                return employeeRepository;
            }
        }
    }
}
