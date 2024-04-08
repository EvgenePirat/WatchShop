using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.AdditionalCharacteristics.Response;

namespace WatchShop_Core.Mappers
{
    public class AdditionalCharacteristicsModelProfile : Profile
    {
        public AdditionalCharacteristicsModelProfile()
        {
            CreateMap<AdditionalCharacteristics, AdditionalCharacteristicModel>();
        }
    }
}
