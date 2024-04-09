using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.WatchAdditionalCharacteristics.Request;
using WatchShop_Core.Models.WatchAdditionalCharacteristics.Response;

namespace WatchShop_Core.Mappers
{
    public class WatchAdditionalCharacteristicModelProfile : Profile
    {
        public WatchAdditionalCharacteristicModelProfile()
        {
            CreateMap<CreateWatchAdditionalCharacteristicModel, WatchAdditionalCharacteristic>();
            CreateMap<WatchAdditionalCharacteristic, WatchAdditionalCharacteristicModel>();
        }
    }
}
