using AutoMapper;
using WatchShop_Core.Models.StrapMaterials.Response;
using WatchShop_UI.Dtos.StrapMaterials.Response;

namespace WatchShop_UI.Mappers
{
    public class StrapMaterialDtoProfile : Profile
    {
        public StrapMaterialDtoProfile()
        {
            CreateMap<StrapMaterialModel, StrapMaterialDto>();
        }
    }
}
