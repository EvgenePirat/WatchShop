using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Watches.Request;
using WatchShop_Core.Models.Watches.Response;

namespace WatchShop_Core.ServiceContracts
{
    public interface IWatchService
    {
        public Task<WatchCharactersModel> GetWatchCharactersAsync();
        public Task<WatchModel> CreateWatchAsync(CreateWatchModel createWatch);
        public Task<IEnumerable<WatchModel>> GetAllWatchesAsync();
        public Task<WatchModel> GetByNameModelAsync(string nameModel);
        public Task<WatchModel> UpdateWatchAsync(int watchId, UpdateWatchModel updateWatch);
    }
}
