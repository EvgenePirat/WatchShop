using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Domain.Contracts;

namespace WatchShop_Core.Domain.Entities.Identities
{
    public class ApplicationUser : IdentityUser<Guid>, IEntity
    {
        [StringLength(30)]
        public string? City { get; set; }

        [StringLength(13)]
        public string? Phone { get; set; }

        public DateOnly? DateOfBorthd { get; set; }

        public IEnumerable<WatchComment>? Comments { get; set; }
    }
}
