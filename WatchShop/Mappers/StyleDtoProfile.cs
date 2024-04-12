using AutoMapper;
using WatchShop_Core.Models.Styles.Response;
using WatchShop_UI.Dtos.Styles.Response;

namespace WatchShop_UI.Mappers
{
    public class StyleDtoProfile : Profile
    {
        public StyleDtoProfile()
        {
            CreateMap<StyleModel, StyleDto>();
        }
    }
}
