using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Brends.Request;
using WatchShop_Core.Models.Brends.Response;

namespace WatchShop_Core.Mappers
{
    public class BrendModelProfile : Profile
    {
        public BrendModelProfile()
        {
            CreateMap<CreateBrendModel, Brend>();
            CreateMap<UpdateBrendModel, Brend>();
            CreateMap<Brend, BrendModel>();
        }
    }
}
