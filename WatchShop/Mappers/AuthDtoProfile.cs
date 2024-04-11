using AutoMapper;
using WatchShop_Core.Models.Auth.Request;
using WatchShop_Core.Models.Auth.Response;
using WatchShop_UI.Dtos.Auth.Request;
using WatchShop_UI.Dtos.Auth.Response;

namespace WatchShop_UI.Mappers
{
    public class AuthDtoProfile : Profile
    {
        public AuthDtoProfile()
        {
            CreateMap<LoginDto, LoginModel>();
            CreateMap<RegisterDto, RegisterModel>();
            CreateMap<AuthResponseModel, AuthResponseDto>();
        }
    }
}
