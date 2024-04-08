using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WatchShop_Core.Domain.Contracts;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Infrastructure.DbContext;
using WatchShop_Infrastructure.Utilities;

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

        public async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            return await _context.Set<TEntity>().IncludeMultiple(includes).ToListAsync();
        }

        public void Update(TEntity entity)
        {
            var dbTable = _context.Set<TEntity>();
            dbTable.Update(entity);
        }
    }
}
