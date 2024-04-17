using WatchShop_Core.Models.Carts.Request;
using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.Orders.Request
{
    public class UpdateOrderModel
    {
        public double Sum { get; set; }

        public Guid UserId { get; set; }

        public OrderStatusEnum OrderStatus { get; set; }

        public IEnumerable<UpdateCartModel> Carts { get; set; }

        public string? Comment { get; set; }
    }
}
