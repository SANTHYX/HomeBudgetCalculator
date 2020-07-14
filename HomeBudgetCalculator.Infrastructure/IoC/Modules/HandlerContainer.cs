using Autofac;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using System.Reflection;

namespace HomeBudgetCalculator.Infrastructure.IoC.Modules
{
    public class HandlerContainer : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(HandlerContainer).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<ICommandHandler>())
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
