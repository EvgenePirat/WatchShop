using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Orders.Request;
using WatchShop_Core.Models.Orders.Response;

namespace WatchShop_Core.Mappers
{
    public class OrderModelProfile : Profile
    {
        public OrderModelProfile()
        {
            CreateMap<CreateOrderModel, Order>();
            CreateMap<UpdateOrderModel, Order>();
            CreateMap<Order, OrderModel>();
        }
    }
}
