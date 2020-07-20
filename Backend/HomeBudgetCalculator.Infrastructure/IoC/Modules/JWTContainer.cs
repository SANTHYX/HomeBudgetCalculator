using Autofac;
using HomeBudgetCalculator.Infrastructure.JWT;
using HomeBudgetCalculator.Infrastructure.JWT.Interfaces;

namespace HomeBudgetCalculator.Infrastructure.IoC.Modules
{
    public class JWTContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Encrypter>().As<IEncrypter>().SingleInstance();

            builder.RegisterType<JWTHandler>().As<IJWTHandler>().SingleInstance();
        }
    }
}
