using AutoMapper;
using WatchShop_Core.Domain.Entities.Identities;
using WatchShop_Core.Models.Users.Request;
using WatchShop_Core.Models.Users.Response;

namespace WatchShop_Core.Mappers
{
    public class UserModelProfile : Profile
    {
        public UserModelProfile()
        {
            CreateMap<UpdateUserModel, ApplicationUser>();
            CreateMap<ApplicationUser, UserModel>();
        }
    }
}
