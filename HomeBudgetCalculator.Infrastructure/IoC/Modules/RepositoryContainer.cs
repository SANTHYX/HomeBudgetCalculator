using Autofac;
using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using System.Reflection;

namespace HomeBudgetCalculator.Infrastructure.IoC.Modules
{
    public class RepositoryContainer : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryContainer).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
