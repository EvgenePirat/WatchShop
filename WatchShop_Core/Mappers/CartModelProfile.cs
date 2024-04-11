using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Carts.Request;
using WatchShop_Core.Models.Carts.Response;

namespace WatchShop_Core.Mappers
{
    public class CartModelProfile : Profile
    {
        public CartModelProfile()
        {
            CreateMap<CreateCartModel, Cart>();
            CreateMap<UpdateCartModel, Cart>();
            CreateMap<Cart, CartModel>();
        }
    }
}
