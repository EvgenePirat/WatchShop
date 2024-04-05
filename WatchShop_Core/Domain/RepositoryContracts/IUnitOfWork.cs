using Microsoft.EntityFrameworkCore.Storage;

namespace WatchShop_Core.Domain.RepositoryContracts
{
    public interface IUnitOfWork
    {
        IBrendRepository BrendRepository { get; }
        Task SaveAsync();
        Task<IDbContextTransaction> BeginTransactionDbContextAsync();
    }
}
