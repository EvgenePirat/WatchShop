using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop_Core.Domain.Entities.Identities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [StringLength(30)]
        public string? City { get; set; }

        [StringLength(13)]
        public string? Phone { get; set; }

        public DateOnly? DateOfBorthd { get; set; }
    }
}
