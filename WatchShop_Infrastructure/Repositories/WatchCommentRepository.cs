using Microsoft.EntityFrameworkCore;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Infrastructure.DbContext;

namespace WatchShop_Infrastructure.Repositories
{
    public class WatchCommentRepository : RepositoryBase<WatchComment>, IWatchCommentRepository
    {
        public WatchCommentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<WatchComment>?> FindCommentByUserNameAsync(string username)
        {
            var commentWatches = await _context.WatchComments.Include(cw => cw.User).ToListAsync();
            return commentWatches.FindAll(cw => cw.User.UserName.ToLower() == username.ToLower());
        }

        public async Task<IEnumerable<WatchComment>?> FindCommentByWatchNameModelAsync(string nameModel)
        {
            var commentWatches = await _context.WatchComments.Include(cw => cw.Watch).ToListAsync();
            return commentWatches.FindAll(cw => cw.Watch.NameModel.ToLower() == nameModel.ToLower());
        }

        public async Task<WatchComment?> GetByIdAsync(Guid id)
        {
            return await _context.WatchComments.FirstOrDefaultAsync(cw => cw.Id == id);
        }
    }
}
