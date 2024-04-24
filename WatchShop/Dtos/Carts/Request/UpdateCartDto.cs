namespace WatchShop_UI.Dtos.Carts.Request
{
    public class UpdateCartDto
    {
        public Guid OrderId { get; set; }

        public int WatchId { get; set; }

        public int Count { get; set; }
    }
}
