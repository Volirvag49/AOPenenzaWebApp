using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using WebApp.Infrastructure.NinjectModules;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            string connectionString = ConfigurationManager.ConnectionStrings["WebAppConnection"].ConnectionString;
            NinjectModule serviceModule = new ServiceModule(connectionString);
            NinjectModule autoMapperModule = new AutoMapperModule();

            var kernel = new StandardKernel(serviceModule, autoMapperModule);


            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
