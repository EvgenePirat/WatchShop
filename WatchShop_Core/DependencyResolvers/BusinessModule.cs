using Autofac;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.ServiceContracts;
using WatchShop_Core.Services;

namespace WatchShop_Core.DependencyResolvers
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BrendService>().As<IBrendService>();
            builder.RegisterType<WatchService>().As<IWatchService>();
            builder.RegisterType<BlobService>().As<IBlobService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<AuthenticateService>().As<IAuthenticateService>();
            builder.RegisterType<JwtService>().As<IJwtService>();
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}
