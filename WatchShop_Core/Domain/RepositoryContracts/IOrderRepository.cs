using WatchShop_Core.Domain.Entities;

namespace WatchShop_Core.Domain.RepositoryContracts
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<Order?> GetByIdAsync(Guid id);
        Task<IEnumerable<Order>> FindOrdersByUserNameAsync(string username);
    }
}
