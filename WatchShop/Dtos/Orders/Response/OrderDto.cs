using WatchShop_Core.Models.Payments.Response;
using WatchShop_Core.Models.Shipments.Response;
using WatchShop_UI.Dtos.Carts.Response;
using WatchShop_UI.Dtos.OrderStatuses.Response;
using WatchShop_UI.Dtos.Payments.Response;
using WatchShop_UI.Dtos.Shipments.Response;

namespace WatchShop_UI.Dtos.Orders.Response
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public double Sum { get; set; }

        public Guid UserId { get; set; }

        public OrderStatusDto OrderStatus { get; set; }

        public ShipmentDto Shipment { get; set; }

        public PaymentDto Payment { get; set; }

        public IEnumerable<CartDto>? Carts { get; set; }

        public string? Comment { get; set; }
    }
}
