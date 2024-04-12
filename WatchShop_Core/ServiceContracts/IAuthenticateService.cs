using WatchShop_Core.Models.Auth.Request;
using WatchShop_Core.Models.Auth.Response;

namespace WatchShop_Core.ServiceContracts
{
    public interface IAuthenticateService
    {
        Task<AuthResponseModel> LoginAsync(LoginModel model);

        Task<RegisterResponseModel> RegisterAsync(RegisterModel model);
    }
}
