using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    public class OrderStatus
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public OrderStatusEnum? Name { get; set; }
    }
}
