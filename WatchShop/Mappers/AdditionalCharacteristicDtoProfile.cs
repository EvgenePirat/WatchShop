using AutoMapper;
using WatchShop_Core.Models.AdditionalCharacteristics.Response;
using WatchShop_UI.Dtos.AdditionalCharacteristics.Response;

namespace WatchShop_UI.Mappers
{
    public class AdditionalCharacteristicDtoProfile : Profile
    {
        public AdditionalCharacteristicDtoProfile()
        {
            CreateMap<AdditionalCharacteristicModel, AdditionalCharacteristicDto>();
        }
    }
}
