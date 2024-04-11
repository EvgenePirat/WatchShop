using WatchShop_Core.Models.Carts.Request;

namespace WatchShop_Core.Models.Orders.Request
{
    public class UpdateOrderModel
    {
        public double Sum { get; set; }

        public Guid UserId { get; set; }

        public byte OrderStatusId { get; set; }

        public IEnumerable<UpdateCartModel> Carts { get; set; }
    }
}
