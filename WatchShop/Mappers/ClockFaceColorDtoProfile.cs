using AutoMapper;
using WatchShop_Core.Models.ClockFaceColors.Response;
using WatchShop_UI.Dtos.ClockFaceColors.Response;

namespace WatchShop_UI.Mappers
{
    public class ClockFaceColorDtoProfile : Profile
    {
        public ClockFaceColorDtoProfile()
        {
            CreateMap<ClockFaceColorModel, ClockFaceColorDto>();
        }
    }
}
