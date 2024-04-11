using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.Auth.Request
{
    public class RegisterModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public RoleEnum Role { get; set; }
    }
}
