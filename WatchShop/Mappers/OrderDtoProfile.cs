using AutoMapper;
using WatchShop_Core.Models.Orders.Request;
using WatchShop_Core.Models.Orders.Response;
using WatchShop_UI.Dtos.Orders.Request;
using WatchShop_UI.Dtos.Orders.Response;

namespace WatchShop_UI.Mappers
{
    public class OrderDtoProfile : Profile
    {
        public OrderDtoProfile()
        {
            CreateMap<CreateOrderDto, CreateOrderModel>();
            CreateMap<UpdateOrderDto, UpdateOrderModel>();
            CreateMap<OrderModel, OrderDto>();
        }
    }
}
