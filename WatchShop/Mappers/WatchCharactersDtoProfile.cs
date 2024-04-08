using AutoMapper;
using WatchShop_Core.Models.Watches.Response;
using WatchShop_UI.Dtos.Products.Response;

namespace WatchShop_UI.Mappers
{
    public class WatchCharactersDtoProfile : Profile
    {
        public WatchCharactersDtoProfile()
        {
            CreateMap<WatchCharactersModel, WatchCharactersDto>();
        }
    }
}
