using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Images.Response;

namespace WatchShop_Core.Mappers
{
    public class ImageModelProfile : Profile
    {
        public ImageModelProfile()
        {
            CreateMap<Image, ImageModel>();
        }
    }
}
