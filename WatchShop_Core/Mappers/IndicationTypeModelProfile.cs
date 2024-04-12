using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.IndicationTypes.Response;

namespace WatchShop_Core.Mappers
{
    public class IndicationTypeModelProfile : Profile
    {
        public IndicationTypeModelProfile()
        {
            CreateMap<IndicationType, IndicationTypeModel>();
        }
    }
}
