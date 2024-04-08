using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.FrameMaterials.Response;

namespace WatchShop_Core.Mappers
{
    public class FrameMaterialModelProfile : Profile
    {
        public FrameMaterialModelProfile()
        {
            CreateMap<FrameMaterial, FrameMaterialModel>();
        }
    }
}
