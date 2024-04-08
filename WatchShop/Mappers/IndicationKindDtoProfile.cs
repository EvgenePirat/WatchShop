using AutoMapper;
using WatchShop_Core.Models.IndicationKinds.Response;
using WatchShop_UI.Dtos.IndicationKinds.Response;

namespace WatchShop_UI.Mappers
{
    public class IndicationKindDtoProfile : Profile
    {
        public IndicationKindDtoProfile()
        {
            CreateMap<IndicationKindModel, IndicationKindDto>();
        }
    }
}
