using Autofac;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Infrastructure.Repositories;

namespace WatchShop_Infrastructure.DependencyResolvers
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}
