using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DAL.Contexts;
using Services.LoggingService;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using WebAPILab.Models;

namespace WebAPILab
{
    public static class ContainerConfig
    {
        public static void Configure()
        {
            IContainer builtContainer = RegisterAndBuild();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builtContainer));
        }

        private static IContainer RegisterAndBuild()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly());
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            containerBuilder.RegisterType<HomeViewModel>().As<IHomeViewModel>();
            containerBuilder.RegisterType<Logger>().As<ILogger>();
            containerBuilder.RegisterType<DatabaseContext>().As<IDatabaseContext>();

            return containerBuilder.Build();
        }

        private static void RegisterAssemblyWithInterfaces(ContainerBuilder containerBuilder, string assemblyName, string theNameSpace)
        {
            containerBuilder.RegisterAssemblyTypes(Assembly.Load(assemblyName))
                .Where(x => x.Namespace.Contains(theNameSpace))
                .As(x => x.GetInterfaces().FirstOrDefault(i => i.Name == $"I{i.Name}"));
        }
    }
}