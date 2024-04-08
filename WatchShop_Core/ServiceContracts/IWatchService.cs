using WatchShop_Core.Models.Watches.Response;

namespace WatchShop_Core.ServiceContracts
{
    public interface IWatchService
    {
        public Task<WatchCharactersModel> GetWatchCharactersAsync();
    }
}
