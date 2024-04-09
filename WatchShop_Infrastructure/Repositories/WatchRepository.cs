using Microsoft.EntityFrameworkCore;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Infrastructure.DbContext;

namespace WatchShop_Infrastructure.Repositories
{
    public class WatchRepository : RepositoryBase<Watch>, IWatchRepository
    {
        public WatchRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Watch?> FindByNameModelAsync(string nameModel)
        {
            return await _context.Watches.FirstOrDefaultAsync(b => b.NameModel.ToLower() == nameModel.ToLower());
        }

        public async Task<Watch?> GetByIdAsync(int id)
        {
            return await _context.Watches.FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
