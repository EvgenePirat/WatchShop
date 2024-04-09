using AutoMapper;
using WatchShop_Core.Models.Dimensions.Request;
using WatchShop_Core.Models.Dimensions.Response;
using WatchShop_UI.Dtos.Dimensions.Request;
using WatchShop_UI.Dtos.Dimensions.Response;

namespace WatchShop_UI.Mappers
{
    public class DimensionDtoProfile : Profile
    {
        public DimensionDtoProfile()
        {
            CreateMap<CreateDimensionDto, CreateDimensionModel>();
            CreateMap<DimensionModel, DimensionDto>();
        }
    }
}
