using AutoMapper;
using WatchShop_Core.Models.Users.Request;
using WatchShop_Core.Models.Users.Response;
using WatchShop_UI.Dtos.Users.Request;
using WatchShop_UI.Dtos.Users.Response;

namespace WatchShop_UI.Mappers
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<UpdateUserDto, UpdateUserModel>();
            CreateMap<UserModel, UserDto>();
        }
    }
}
