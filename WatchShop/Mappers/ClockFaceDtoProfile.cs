using AutoMapper;
using WatchShop_Core.Models.ClockFaces.Request;
using WatchShop_Core.Models.ClockFaces.Response;
using WatchShop_UI.Dtos.ClockFaces.Request;
using WatchShop_UI.Dtos.ClockFaces.Response;

namespace WatchShop_UI.Mappers
{
    public class ClockFaceDtoProfile : Profile
    {
        public ClockFaceDtoProfile()
        {
            CreateMap<CreateClockFaceDto, CreateClockFaceModel>();
            CreateMap<ClockFaceModel, ClockFaceDto>();
        }
    }
}
