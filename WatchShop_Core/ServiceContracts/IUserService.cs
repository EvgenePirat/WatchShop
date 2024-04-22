using Stripe;
using WatchShop_Core.Models.Brends.Request;
using WatchShop_Core.Models.Brends.Response;
using WatchShop_Core.Models.Users.Request;
using WatchShop_Core.Models.Users.Response;

namespace WatchShop_Core.ServiceContracts
{
    public interface IUserService
    {
        Task<UserModel> UpdateUserAsync(Guid id, UpdateUserModel model);
        Task<bool> SetSubscriptionLetters(string email, bool isActive);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task DeleteUserAsync(Guid id);
        Task<UserModel> GetUserByUserNameAsync(string username);
        Task<UserModel> GetUserByIdAsync(Guid id);
    }
}
