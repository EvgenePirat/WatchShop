using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Contracts;
using WatchShop_Core.Domain.Entities.Identities;

namespace WatchShop_Core.Domain.Entities
{
    [Table("orders")]
    public class Order : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public double Sum { get; set; }
        
        public Guid? UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser?  User { get; set; }

        [Required]
        public byte OrderStatusId { get; set; }

        [ForeignKey("OrderStatusId")]
        public OrderStatus? OrderStatus { get; set; }

        [Required]
        public IEnumerable<Cart>? Carts { get; set; }

        [Required]
        public Guid ShipmentId { get; set; }

        [ForeignKey("ShipmentId")]
        public Shipment Shipment { get; set; }

        [Required]
        public Guid PaymentId { get; set; }

        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; }

        [StringLength(100)]
        public string? Comment { get; set; }
    }
}
