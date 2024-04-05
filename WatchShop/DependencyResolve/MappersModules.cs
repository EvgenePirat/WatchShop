using Autofac;
using AutoMapper;
using WatchShop_Core.Mappers;
using WatchShop_UI.Mappers;

namespace WatchShop_UI.DependencyResolve
{
    public class MappersModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new MapperConfiguration(cfg =>
            {

                cfg.AddProfile(new BrendModelProfile());
                cfg.AddProfile(new BrendDtoProfile());


            })).SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper())
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
