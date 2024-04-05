using WatchShop_Core.Domain.Entities;

namespace WatchShop_Core.Domain.RepositoryContracts
{
    public interface IBrendRepository : IRepositoryBase<Brend> 
    {
        Task<Brend?> GetByIdAsync(int id);
        Task<Brend?> FindByBrendNameAsync(string name);
    }
}
