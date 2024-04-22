using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Contracts;
using WatchShop_Core.Domain.Entities.Identities;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    [Table("payments")]
    public class Payment : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        public string? StripeIntendId { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        public PaymentStatus Status { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required] 
        public Guid ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public Order Order { get; set; }
    }
}
