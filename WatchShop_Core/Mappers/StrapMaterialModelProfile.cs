using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.StrapMaterials.Response;

namespace WatchShop_Core.Mappers
{
    public class StrapMaterialModelProfile : Profile
    {
        public StrapMaterialModelProfile()
        {
            CreateMap<StrapMaterial, StrapMaterialModel>();
        }
    }
}
