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

                cfg.AddProfile(new WatchAdditionalCharacteristicDtoProfile());
                cfg.AddProfile(new WatchAdditionalCharacteristicModelProfile());

                cfg.AddProfile(new WatchDtoProfile());
                cfg.AddProfile(new WatchModelProfile());

                cfg.AddProfile(new ClockFaceModelProfile());
                cfg.AddProfile(new ClockFaceDtoProfile());

                cfg.AddProfile(new DimensionModelProfile());
                cfg.AddProfile(new DimensionDtoProfile());

                cfg.AddProfile(new FrameModelProfile());
                cfg.AddProfile(new FrameDtoProfile());

                cfg.AddProfile(new StrapModelProfile());
                cfg.AddProfile(new StrapDtoProfile());

                cfg.AddProfile(new AdditionalCharacteristicsModelProfile());
                cfg.AddProfile(new AdditionalCharacteristicDtoProfile());

                cfg.AddProfile(new ClockFaceColorModelProfile());
                cfg.AddProfile(new ClockFaceColorDtoProfile());

                cfg.AddProfile(new CountryModelProfile());
                cfg.AddProfile(new CountryDtoProfile());

                cfg.AddProfile(new FrameColorModelProfile());
                cfg.AddProfile(new FrameColorDtoProfile());

                cfg.AddProfile(new FrameMaterialModelProfile());
                cfg.AddProfile(new FrameMaterialDtoProfile());

                cfg.AddProfile(new GlassTypeModelProfile());
                cfg.AddProfile(new GlassTypeDtoProfile());

                cfg.AddProfile(new IndicationKindModelProfile());
                cfg.AddProfile(new IndicationKindDtoProfile());

                cfg.AddProfile(new IndicationTypeModelProfile());
                cfg.AddProfile(new IndicationTypeDtoProfile());

                cfg.AddProfile(new MechanismTypeModelProfile());
                cfg.AddProfile(new MechanismTypeDtoProfile());

                cfg.AddProfile(new StrapMaterialModelProfile());
                cfg.AddProfile(new StrapMaterialDtoProfile());

                cfg.AddProfile(new StyleModelProfile());
                cfg.AddProfile(new StyleDtoProfile());

                cfg.AddProfile(new WatchCharactersDtoProfile());


            })).SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper())
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
