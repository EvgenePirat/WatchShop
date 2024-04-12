using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.IndicationKinds.Response;

namespace WatchShop_Core.Mappers
{
    public class IndicationKindModelProfile : Profile
    {
        public IndicationKindModelProfile()
        {
            CreateMap<IndicationKind, IndicationKindModel>();
        }
    }
}
