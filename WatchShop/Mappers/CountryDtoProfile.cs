using AutoMapper;
using WatchShop_Core.Models.Countries.Response;
using WatchShop_UI.Dtos.Countries.Response;

namespace WatchShop_UI.Mappers
{
    public class CountryDtoProfile : Profile
    {
        public CountryDtoProfile()
        {
            CreateMap<CountryModel, CountryDto>();
        }
    }
}
