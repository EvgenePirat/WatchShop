using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Watches.Request;
using WatchShop_Core.Models.Watches.Response;
using WatchShop_UI.Dtos.Watches.Request;
using WatchShop_UI.Dtos.Watches.Response;

namespace WatchShop_UI.Mappers
{
    public class WatchDtoProfile : Profile
    {
        public WatchDtoProfile()
        {
            CreateMap<CreateWatchDto, CreateWatchModel>();
            CreateMap<WatchModel, WatchDto>();
        }
    }
}
