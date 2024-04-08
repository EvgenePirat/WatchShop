using AutoMapper;
using WatchShop_Core.Models.FrameColors.Response;
using WatchShop_UI.Dtos.FrameColors.Response;

namespace WatchShop_UI.Mappers
{
    public class FrameColorDtoProfile : Profile
    {
        public FrameColorDtoProfile()
        {
            CreateMap<FrameColorModel, FrameColorDto>();
        }
    }
}
