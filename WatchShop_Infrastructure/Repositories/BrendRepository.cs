using Microsoft.EntityFrameworkCore;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Infrastructure.DbContext;

namespace WatchShop_Infrastructure.Repositories
{
    public class BrendRepository : RepositoryBase<Brend>, IBrendRepository
    {
        public BrendRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Brend?> FindByBrendNameAsync(string name)
        {
            return await _context.Brends.FirstOrDefaultAsync(b => b.Name.ToLower() == name.ToLower());
        }

        public async Task<Brend?> GetByIdAsync(int id)
        {
            return await _context.Brends.FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
