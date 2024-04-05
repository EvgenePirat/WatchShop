using WatchShop_Core.Domain.Contracts;

namespace WatchShop_Core.Domain.RepositoryContracts
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntity, new()
    {
        void Add(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
