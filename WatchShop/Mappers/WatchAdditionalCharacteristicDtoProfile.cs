using AutoMapper;
using WatchShop_Core.Models.WatchAdditionalCharacteristics.Request;
using WatchShop_Core.Models.WatchAdditionalCharacteristics.Response;
using WatchShop_UI.Dtos.WatchAdditionalCharacteristics.Request;
using WatchShop_UI.Dtos.WatchAdditionalCharacteristics.Response;

namespace WatchShop_UI.Mappers
{
    public class WatchAdditionalCharacteristicDtoProfile : Profile
    {
        public WatchAdditionalCharacteristicDtoProfile()
        {
            CreateMap<CreateWatchAdditionalCharacteristicDto, CreateWatchAdditionalCharacteristicModel>();
            CreateMap<WatchAdditionalCharacteristicModel, WatchAdditionalCharacteristicDto>();
        }
    }
}
