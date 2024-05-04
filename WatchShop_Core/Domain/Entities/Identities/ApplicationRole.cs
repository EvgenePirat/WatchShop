using Microsoft.AspNetCore.Identity;
using WatchShop_Core.Domain.Contracts;

namespace WatchShop_Core.Domain.Entities.Identities
{
    public class ApplicationRole : IdentityRole<Guid>, IEntity
    {
    }
}
