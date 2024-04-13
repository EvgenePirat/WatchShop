using WatchShop_Core.Models.Brends.Request;
using WatchShop_Core.Models.Brends.Response;

namespace WatchShop_Core.ServiceContracts
{
    public interface IBrendService
    {
        Task<BrendModel> CreateBrendAsync(CreateBrendModel model);
        Task<BrendModel> UpdateBrendAsync(int id, UpdateBrendModel model);
        Task<IEnumerable<BrendAllModel>> GetAllBrendsAsync();
        Task DeleteBrendAsync(int id);
        Task<BrendModel?> GetBrendByNameAsync(string name);
        Task<BrendModel?> GetBrendByIdAsync(int id);
    }
}
