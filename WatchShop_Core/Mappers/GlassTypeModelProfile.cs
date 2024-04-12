using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.GlassTypes.Response;

namespace WatchShop_Core.Mappers
{
    public class GlassTypeModelProfile : Profile
    {
        public GlassTypeModelProfile()
        {
            CreateMap<GlassType, GlassTypeModel>();
        }
    }
}
