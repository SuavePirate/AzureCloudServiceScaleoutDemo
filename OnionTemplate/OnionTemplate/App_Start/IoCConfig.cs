using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OnionTemplate.Application.Interfaces.Services;
using OnionTemplate.Domain.Interfaces.Repositories;
using OnionTemplate.Infrastructure.Business.Services;
using OnionTemplate.Infrastructure.Data.Contexts;
using OnionTemplate.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OnionTemplate
{
    public class IoCConfig
    {
        public static IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType(typeof(ApplicationContext)).InstancePerLifetimeScope();

            // repositories
            builder.RegisterType(typeof(UserRepository)).As(typeof(IUserRepository)).InstancePerLifetimeScope();
            

            // services
            builder.RegisterType(typeof(UserService)).As(typeof(IUserService)).InstancePerLifetimeScope();
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;
        }
    }
}