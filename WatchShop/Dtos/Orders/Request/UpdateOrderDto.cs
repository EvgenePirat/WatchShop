using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Models.Carts.Request;
using WatchShop_UI.Dtos.Carts.Request;

namespace WatchShop_UI.Dtos.Orders.Request
{
    public class UpdateOrderDto
    {
        [Required]
        public double Sum { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string OrderStatus { get; set; }

        [Required]
        public IEnumerable<UpdateCartDto> Carts { get; set; }

        public string? Comment { get; set; }
    }
}
