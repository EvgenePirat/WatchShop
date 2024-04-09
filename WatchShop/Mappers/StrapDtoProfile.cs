using AutoMapper;
using WatchShop_Core.Models.Straps.Request;
using WatchShop_Core.Models.Straps.Response;
using WatchShop_UI.Dtos.Straps.Request;
using WatchShop_UI.Dtos.Straps.Response;

namespace WatchShop_UI.Mappers
{
    public class StrapDtoProfile : Profile
    {
        public StrapDtoProfile()
        {
            CreateMap<CreateStrapDto, CreateStrapModel>();
            CreateMap<UpdateStrapDto, UpdateStrapModel>();
            CreateMap<StrapModel, StrapDto>();
        }
    }
}
