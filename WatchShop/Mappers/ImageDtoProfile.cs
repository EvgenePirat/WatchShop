using AutoMapper;
using WatchShop_Core.Models.Images.Response;
using WatchShop_UI.Dtos.Images.Response;

namespace WatchShop_UI.Mappers
{
    public class ImageDtoProfile : Profile
    {
        public ImageDtoProfile()
        {
            CreateMap<ImageModel, ImageDto>();
        }
    }
}
