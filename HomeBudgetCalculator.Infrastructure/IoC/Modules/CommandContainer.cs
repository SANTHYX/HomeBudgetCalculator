using Autofac;
using HomeBudgetCalculator.Infrastructure.Commands.Interface;
using System.Reflection;

namespace HomeBudgetCalculator.Infrastructure.IoC.Modules
{
    public class CommandContainer : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandContainer).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<ICommand>())
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
