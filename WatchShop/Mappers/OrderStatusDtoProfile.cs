using AutoMapper;
using WatchShop_Core.Models.OrderStatuses.Response;
using WatchShop_UI.Dtos.OrderStatuses.Response;

namespace WatchShop_UI.Mappers
{
    public class OrderStatusDtoProfile : Profile
    {
        public OrderStatusDtoProfile()
        {
            CreateMap<OrderStatusModel, OrderStatusDto>();
        }
    }
}
