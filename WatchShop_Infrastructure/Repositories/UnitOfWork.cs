using Microsoft.EntityFrameworkCore.Storage;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Infrastructure.DbContext;

namespace WatchShop_Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IBrendRepository _brendRepository;

        public IBrendRepository BrendRepository => _brendRepository ??= new BrendRepository(_context);

        public async Task<IDbContextTransaction> BeginTransactionDbContextAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
