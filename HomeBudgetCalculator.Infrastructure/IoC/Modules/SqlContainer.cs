using Autofac;
using HomeBudgetCalculator.Infrastructure.EntityFramework.Interface;
using System.Reflection;

namespace HomeBudgetCalculator.Infrastructure.IoC.Modules
{
    public class SqlContainer : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var asembly = typeof(SqlContainer).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(asembly).Where(x => x.IsAssignableTo<ISqlRepository>())
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
