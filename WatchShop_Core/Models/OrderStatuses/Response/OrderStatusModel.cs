using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.OrderStatuses.Response
{
    public class OrderStatusModel
    {
        public byte Id { get; set; }

        public OrderStatusEnum Name { get; set; }
    }
}
