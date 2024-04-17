using WatchShop_Core.Models.Watches.Response;
using WatchShop_UI.Dtos.Watches.Response;

namespace WatchShop_UI.Dtos.Carts.Response
{
    public class CartDto
    {
        public int WatchId { get; set; }

        public int Count { get; set; }
    }
}
