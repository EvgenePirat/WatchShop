using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Infrastructure.DbContext;

namespace WatchShop_Infrastructure.Repositories
{
    public class ClockFaceColorRepository : RepositoryBase<ClockFaceColor>, IClockFaceColorRepository
    {
        public ClockFaceColorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
