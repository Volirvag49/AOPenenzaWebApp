using AOPenenzaTest.BLL.AbstractEmployeeService;
using AOPenenzaTest.BLL.EmployeeService;
using AOPenenzaTest.DAL.AbstractRepository;
using AOPenenzaTest.DAL.RepositoryEF;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

namespace WebApp.Infrastructure.NinjectModules
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {

            Bind<UnitOfWork>().ToSelf().InRequestScope().WithConstructorArgument(connectionString);
            Bind<IUnitOfWork>().ToMethod(ctx => ctx.Kernel.Get<UnitOfWork>());

            Bind<EmployeeService>().ToSelf().InRequestScope();
            Bind<IEmployeeGetService>().ToMethod(ctx => ctx.Kernel.Get<EmployeeService>());
            Bind<IEmployeeCRUDService>().ToMethod(ctx => ctx.Kernel.Get<EmployeeService>());

            Bind<EmployeeStatisticsService>().ToSelf().InRequestScope();
            Bind<IEmployeeStatisticsService>().ToMethod(ctx => ctx.Kernel.Get<EmployeeStatisticsService>());

        }
    }    
}