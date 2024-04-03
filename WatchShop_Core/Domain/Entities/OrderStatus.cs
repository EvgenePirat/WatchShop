using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    [Table("order_statuses")]
    public class OrderStatus
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public OrderStatusEnum? Name { get; set; }

        public IEnumerable<Order>? Orders { get; set; }
    }
}
