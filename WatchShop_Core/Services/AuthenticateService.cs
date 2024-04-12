using Microsoft.AspNetCore.Identity;
using WatchShop_Core.Domain.Entities.Identities;
using WatchShop_Core.Exceptions;
using WatchShop_Core.Models.Auth.Request;
using WatchShop_Core.Models.Auth.Response;
using WatchShop_Core.Models.Enums;
using WatchShop_Core.ServiceContracts;

namespace WatchShop_Core.Services
{
    public class AuthenticateService : IAuthenticateService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthenticateService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<AuthResponseModel> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if(user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                
            }

            return null;
        }

        public async Task<AuthResponseModel> Register(RegisterModel model)
        {
            var userExist = await _userManager.FindByNameAsync(model.Username);
            if (userExist != null)
            {
                throw new AuthArgumentException("User with username already exist");
            }

            ApplicationUser user = new ApplicationUser()
            {
                UserName = model.Username,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                throw new AuthArgumentException("User creation failed!");

            await _userManager.AddToRoleAsync(user, model.Role.ToString());

            return new AuthResponseModel() { UserId = user.Id, Username = user.UserName};
        }
    }
}
