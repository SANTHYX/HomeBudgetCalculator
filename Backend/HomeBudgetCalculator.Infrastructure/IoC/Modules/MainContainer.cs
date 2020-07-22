using Autofac;

namespace HomeBudgetCalculator.Infrastructure.IoC.Modules
{
    public class MainContainer : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CommandContainer>();
            builder.RegisterModule<RepositoryContainer>();
            builder.RegisterModule<ServiceContainer>();
            builder.RegisterModule<SqlContainer>();
            builder.RegisterModule<JWTContainer>();
        }
    }
}
