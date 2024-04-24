using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Domain.Contracts;

namespace WatchShop_Core.Domain.Entities.Identities
{
    public class ApplicationUser : IdentityUser<Guid>, IEntity
    {
        [StringLength(100)]
        public string? FirstName { get; set; }

        [StringLength(100)]
        public string? LastName { get; set; }

        [StringLength(30)]
        public string? City { get; set; }

        public bool IsSubscriptionLetters { get; set; } = false;

        public DateTime CreateAccountDate { get; set; }

        public IEnumerable<WatchComment>? Comments { get; set; }

        public IEnumerable<Shipment>? Shipments { get; set; }

        public IEnumerable<Payment>? Payments { get; set; }

        public IEnumerable<Order?> Orders { get; set; }
    }
}
