using Microsoft.EntityFrameworkCore;
using WatchShop_Core.Domain.Contracts;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Infrastructure.DbContext;

namespace WatchShop_Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            var dbTable = _context.Set<TEntity>();
            dbTable.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            var dbTable = _context.Set<TEntity>();
            dbTable.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public void Update(TEntity entity)
        {
            var dbTable = _context.Set<TEntity>();
            dbTable.Update(entity);
        }
    }
}
