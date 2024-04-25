using Microsoft.EntityFrameworkCore;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.Entities.Identities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Infrastructure.DbContext;

namespace WatchShop_Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ApplicationUser?> FindUserByUserNameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<ApplicationUser?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<ApplicationUser?> GetByIdAsync(Guid id)
        {
            return await _context.Users.Include(u => u.Orders).FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
