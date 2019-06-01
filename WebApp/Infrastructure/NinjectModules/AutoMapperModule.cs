using AOPenenzaTest.BLL.AbstractEmployeeService.DTO;
using AOPenenzaTest.DAL.EF.Entities;
using AutoMapper;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Infrastructure.NinjectModules
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
        }

        private IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            Mapper.Initialize(config =>
            {
                config.ConstructServicesUsing(type => context.Kernel.Get(type));

                config.AddProfile<MappingProfile>();

            });

            Mapper.AssertConfigurationIsValid(); // optional
            return Mapper.Instance;
        }
    }
}