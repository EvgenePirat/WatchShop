using AutoMapper;
using WatchShop_Core.Models.Carts.Request;
using WatchShop_Core.Models.Carts.Response;
using WatchShop_UI.Dtos.Carts.Request;
using WatchShop_UI.Dtos.Carts.Response;

namespace WatchShop_UI.Mappers
{
    public class CartDtoProfile : Profile
    {
        public CartDtoProfile()
        {
            CreateMap<CreateCartDto, CreateCartModel>();
            CreateMap<UpdateCartDto, UpdateCartModel>();
            CreateMap<CartModel, CartDto>();
        }
    }
}
