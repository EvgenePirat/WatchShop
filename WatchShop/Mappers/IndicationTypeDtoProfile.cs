using AutoMapper;
using WatchShop_Core.Models.IndicationTypes.Response;
using WatchShop_UI.Dtos.IndicationTypes.Response;

namespace WatchShop_UI.Mappers
{
    public class IndicationTypeDtoProfile : Profile
    {
        public IndicationTypeDtoProfile()
        {
            CreateMap<IndicationTypeModel, IndicationTypeDto>();
        }
    }
}
