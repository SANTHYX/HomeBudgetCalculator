using Autofac;
using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using System.Reflection;

namespace HomeBudgetCalculator.Infrastructure.IoC.Modules
{
    public class RepositoryContainer : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var asembly = typeof(RepositoryContainer).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(asembly).Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
