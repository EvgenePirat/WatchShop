using WatchShop_Core.Domain.Entities;

namespace WatchShop_Core.Domain.RepositoryContracts
{
    public interface IWatchCommentRepository : IRepositoryBase<WatchComment>
    {
        Task<WatchComment?> GetByIdAsync(Guid id);
        Task<IEnumerable<WatchComment>?> FindCommentByUserNameAsync(string username);
        Task<IEnumerable<WatchComment>?> FindCommentByWatchNameModelAsync(string nameModel);
    }
}
