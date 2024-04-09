using AutoMapper;
using WatchShop_Core.Models.Frames.Request;
using WatchShop_Core.Models.Frames.Response;
using WatchShop_UI.Dtos.Frames.Request;
using WatchShop_UI.Dtos.Frames.Response;

namespace WatchShop_UI.Mappers
{
    public class FrameDtoProfile : Profile
    {
        public FrameDtoProfile()
        {
            CreateMap<CreateFrameDto, CreateFrameModel>();
            CreateMap<FrameModel, FrameDto>();
        }
    }
}
