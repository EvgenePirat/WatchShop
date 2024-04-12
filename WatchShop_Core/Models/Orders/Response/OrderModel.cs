using WatchShop_Core.Models.Carts.Response;
using WatchShop_Core.Models.OrderStatuses.Response;

namespace WatchShop_Core.Models.Orders.Response
{
    public class OrderModel
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public double Sum { get; set; }

        public Guid UserId { get; set; }

        public OrderStatusModel OrderStatus { get; set; }

        public IEnumerable<CartModel>? Carts { get; set; }

        public string? Comment { get; set; }
    }
}
