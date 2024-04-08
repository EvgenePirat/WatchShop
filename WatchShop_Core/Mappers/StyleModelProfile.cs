using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Styles.Response;

namespace WatchShop_Core.Mappers
{
    public class StyleModelProfile : Profile
    {
        public StyleModelProfile()
        {
            CreateMap<Style, StyleModel>();
        }
    }
}
