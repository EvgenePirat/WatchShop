using AutoMapper;
using WatchShop_Core.Models.MechanismTypes.Response;
using WatchShop_UI.Dtos.MechanismTypes.Response;

namespace WatchShop_UI.Mappers
{
    public class MechanismTypeDtoProfile : Profile
    {
        public MechanismTypeDtoProfile()
        {
            CreateMap<MechanismTypeModel, MechanismTypeDto>();
        }
    }
}
