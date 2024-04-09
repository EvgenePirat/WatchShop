using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Watches.Request;
using WatchShop_Core.Models.Watches.Response;

namespace WatchShop_Core.Mappers
{
    public class WatchModelProfile : Profile
    {
        public WatchModelProfile()
        {
            CreateMap<CreateWatchModel, Watch>();
            CreateMap<Watch, WatchModel>();
        }
    }
}
