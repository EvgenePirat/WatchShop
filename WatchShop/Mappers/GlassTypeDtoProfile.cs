using AutoMapper;
using WatchShop_Core.Models.GlassTypes.Response;
using WatchShop_UI.Dtos.GlassTypes.Response;

namespace WatchShop_UI.Mappers
{
    public class GlassTypeDtoProfile : Profile
    {
        public GlassTypeDtoProfile()
        {
            CreateMap<GlassTypeModel, GlassTypeDto>();
        }
    }
}
