using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.MechanismTypes.Response;

namespace WatchShop_Core.Mappers
{
    public class MechanismTypeModelProfile : Profile
    {
        public MechanismTypeModelProfile()
        {
            CreateMap<MechanismType, MechanismTypeModel>();
        }
    }
}
