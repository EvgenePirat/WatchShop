using WatchShop_UI.Dtos.Carts.Request;

namespace WatchShop_UI.Dtos.Orders.Request
{
    public class CreateOrderDto
    {
        public double Sum { get; set; }

        public Guid UserId { get; set; }

        public IEnumerable<CreateCartDto> Carts { get; set; }

        public string? Comment { get; set; }
    }
}
