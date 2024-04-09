using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Straps.Request;
using WatchShop_Core.Models.Straps.Response;

namespace WatchShop_Core.Mappers
{
    public class StrapModelProfile : Profile
    {
        public StrapModelProfile()
        {
            CreateMap<Strap, StrapModel>();
            CreateMap<CreateStrapModel, Strap>();
        }
    }
}
