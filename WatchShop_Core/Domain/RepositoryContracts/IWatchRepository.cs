using WatchShop_Core.Domain.Entities;

namespace WatchShop_Core.Domain.RepositoryContracts
{
    public interface IWatchRepository : IRepositoryBase<Watch> 
    {
        Task<Watch?> GetByIdAsync(int id);
        Task<Watch?> FindByNameModelAsync(string nameModel);
    }
}
