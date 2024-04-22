using WatchShop_Core.Models.Payments.Request;
using WatchShop_Core.Models.Shipments.Request;
using WatchShop_UI.Dtos.Carts.Request;
using WatchShop_UI.Dtos.Payments.Request;
using WatchShop_UI.Dtos.Shipments.Request;

namespace WatchShop_UI.Dtos.Orders.Request
{
    public class CreateOrderDto
    {
        public double Sum { get; set; }

        public Guid UserId { get; set; }

        public CreateShipmentDto Shipment { get; set; }

        public CreatePaymentDto Payment { get; set; }

        public IEnumerable<CreateCartDto> Carts { get; set; }

        public string? Comment { get; set; }
    }
}
