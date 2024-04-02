using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchShop_Core.Domain.Entities
{
    public class Cart
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
