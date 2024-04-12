using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.ClockFaceColors.Response;

namespace WatchShop_Core.Mappers
{
    public class ClockFaceColorModelProfile : Profile
    {
        public ClockFaceColorModelProfile()
        {
            CreateMap<ClockFaceColor, ClockFaceColorModel>();
        }
    }
}
