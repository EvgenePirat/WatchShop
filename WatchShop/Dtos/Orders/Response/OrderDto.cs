using WatchShop_UI.Dtos.Carts.Response;
using WatchShop_UI.Dtos.OrderStatuses.Response;

namespace WatchShop_UI.Dtos.Orders.Response
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public double Sum { get; set; }

        public Guid UserId { get; set; }

        public OrderStatusDto OrderStatus { get; set; }

        public IEnumerable<CartDto>? Carts { get; set; }

        public string? Comment { get; set; }
    }
}
