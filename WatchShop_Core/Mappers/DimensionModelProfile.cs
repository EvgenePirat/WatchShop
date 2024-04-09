using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Dimensions.Request;
using WatchShop_Core.Models.Dimensions.Response;

namespace WatchShop_Core.Mappers
{
    public class DimensionModelProfile : Profile
    {
        public DimensionModelProfile()
        {
            CreateMap<CreateDimensionModel, Dimension>();
            CreateMap<Dimension, DimensionModel>();
        }
    }
}
