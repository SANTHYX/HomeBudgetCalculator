using Autofac;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System.Reflection;

namespace HomeBudgetCalculator.Infrastructure.IoC.Modules
{
    public class ServiceContainer : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceContainer).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
