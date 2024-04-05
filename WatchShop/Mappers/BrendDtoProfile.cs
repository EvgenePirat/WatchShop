using AutoMapper;
using WatchShop_Core.Models.Brends.Request;
using WatchShop_Core.Models.Brends.Response;
using WatchShop_UI.Dtos.Brends.Reequest;
using WatchShop_UI.Dtos.Brends.Response;

namespace WatchShop_UI.Mappers
{
    public class BrendDtoProfile : Profile
    {
        public BrendDtoProfile()
        {
            CreateMap<CreateBrendDto, CreateBrendModel>();
            CreateMap<UpdateBrendDto, UpdateBrendModel>();
            CreateMap<BrendModel, BrendDto>();
        }
    }
}
