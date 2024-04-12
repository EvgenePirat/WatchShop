using WatchShop_Core.Domain.Entities.Identities;

namespace WatchShop_Core.Domain.RepositoryContracts
{
    public interface IUserRepository : IRepositoryBase<ApplicationUser>
    {
        Task<ApplicationUser?> GetByIdAsync(Guid id);
        Task<ApplicationUser?> FindUserByUserNameAsync(string username);
    }
}
