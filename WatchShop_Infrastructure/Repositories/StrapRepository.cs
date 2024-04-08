using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Infrastructure.DbContext;

namespace WatchShop_Infrastructure.Repositories
{
    public class StrapRepository : RepositoryBase<Strap>, IStrapRepository
    {
        public StrapRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
