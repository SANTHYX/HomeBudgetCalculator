using Autofac;
using HomeBudgetCalculator.Infrastructure.Commands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using System.Reflection;

namespace HomeBudgetCalculator.Infrastructure.IoC.Modules
{
    public class CommandContainer : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandContainer).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>()
                .InstancePerLifetimeScope();
        }
    }
}
