using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Countries.Response;

namespace WatchShop_Core.Mappers
{
    public class CountryModelProfile : Profile
    {
        public CountryModelProfile()
        {
            CreateMap<Country, CountryModel>();
        }
    }
}
