using Autofac;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System.Reflection;

namespace HomeBudgetCalculator.Infrastructure.IoC.Modules
{
    public class ServiceContainer : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var asembly = typeof(ServiceContainer).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(asembly).Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
