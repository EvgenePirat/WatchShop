using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Domain.Contracts;

namespace WatchShop_Core.Domain.Entities.Identities
{
    public class ApplicationUser : IdentityUser<Guid>, IEntity
    {
        [StringLength(100)]
        public string? FullName { get; set; }

        [StringLength(30)]
        public string? City { get; set; }

        public IEnumerable<WatchComment>? Comments { get; set; }
    }
}
