using WatchShop_Core.Domain.Entities;

namespace WatchShop_Core.Domain.RepositoryContracts
{
    public interface IWatchCommentRepository
    {
        Task<WatchComment?> GetByIdAsync(Guid id);
        Task<IEnumerable<WatchComment>?> FindWatchByUserNameAsync(string username);
    }
}
