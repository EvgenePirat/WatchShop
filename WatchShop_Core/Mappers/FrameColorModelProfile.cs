using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.FrameColors.Response;

namespace WatchShop_Core.Mappers
{
    public class FrameColorModelProfile : Profile
    {
        public FrameColorModelProfile()
        {
            CreateMap<FrameColor, FrameColorModel>();
        }
    }
}
