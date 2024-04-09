using AutoMapper;
using WatchShop_Core.Models.AdditionalCharacteristics.Request;
using WatchShop_Core.Models.AdditionalCharacteristics.Response;
using WatchShop_UI.Dtos.AdditionalCharacteristics.Request;
using WatchShop_UI.Dtos.AdditionalCharacteristics.Response;

namespace WatchShop_UI.Mappers
{
    public class AdditionalCharacteristicDtoProfile : Profile
    {
        public AdditionalCharacteristicDtoProfile()
        {
            CreateMap<AdditionalCharacteristicModel, AdditionalCharacteristicDto>();
            CreateMap<CreateAdditionalCharacteristicDto, CreateAdditionalCharacteristicModel>();
        }
    }
}
