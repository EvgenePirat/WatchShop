using AutoMapper;
using WatchShop_Core.Models.FrameMaterials.Response;
using WatchShop_UI.Dtos.FrameMaterials.Response;

namespace WatchShop_UI.Mappers
{
    public class FrameMaterialDtoProfile : Profile
    {
        public FrameMaterialDtoProfile()
        {
            CreateMap<FrameMaterialModel, FrameMaterialDto>();
        }
    }
}
