using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.ClockFaces.Request;
using WatchShop_Core.Models.ClockFaces.Response;

namespace WatchShop_Core.Mappers
{
    public class ClockFaceModelProfile : Profile
    {
        public ClockFaceModelProfile()
        {
            CreateMap<CreateClockFaceModel, ClockFace>();
            CreateMap<ClockFace, ClockFaceModel>();
        }
    }
}
