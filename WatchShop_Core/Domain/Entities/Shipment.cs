using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Contracts;
using WatchShop_Core.Domain.Entities.Identities;

namespace WatchShop_Core.Domain.Entities
{
    [Table("shipments")]
    public class Shipment : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public string? Country { get; set; }

        [Required]
        public Guid ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser {  get; set; }

        public Order Order { get; set; }
    }
}
