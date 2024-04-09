using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Frames.Request;
using WatchShop_Core.Models.Frames.Response;

namespace WatchShop_Core.Mappers
{
    public class FrameModelProfile : Profile
    {
        public FrameModelProfile()
        {
            CreateMap<CreateFrameModel, Frame>();
            CreateMap<Frame, FrameModel>();
        }
    }
}
