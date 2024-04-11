using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.OrderStatuses.Response;

namespace WatchShop_Core.Mappers
{
    public class OrderStatusModelProfile : Profile
    {
        public OrderStatusModelProfile()
        {
            CreateMap<OrderStatus, OrderStatusModel>();
        }
    }
}
