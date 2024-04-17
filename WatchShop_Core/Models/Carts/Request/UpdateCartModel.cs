namespace WatchShop_Core.Models.Carts.Request
{
    public class UpdateCartModel
    {
        public Guid OrderId { get; set; }

        public int WatchId { get; set; }

        public int Count { get; set; }
    }
}
