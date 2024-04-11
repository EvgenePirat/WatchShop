using WatchShop_Core.Domain.Entities.Identities;

namespace WatchShop_Core.ServiceContracts
{
    public interface IJwtService
    {
        Task<string> CreateJwtTokenAsync(ApplicationUser applicationUser);
    }
}
