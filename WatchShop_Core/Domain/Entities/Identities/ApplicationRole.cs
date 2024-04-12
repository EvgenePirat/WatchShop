using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop_Core.Domain.Contracts;

namespace WatchShop_Core.Domain.Entities.Identities
{
    public class ApplicationRole : IdentityRole<Guid>, IEntity
    {
    }
}
