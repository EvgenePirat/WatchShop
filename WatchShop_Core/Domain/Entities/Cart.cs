using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Contracts;

namespace WatchShop_Core.Domain.Entities
{
    [Table("carts")]
    public class Cart : IEntity
    {
        public int WatchId { get; set; }

        [ForeignKey("WatchId")]
        public Watch? Watch { get; set; }

        public Guid OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
