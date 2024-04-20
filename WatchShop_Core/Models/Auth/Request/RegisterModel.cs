using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.Auth.Request
{
    public class RegisterModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime CreateAccountDate { get; set; } = DateTime.Now;

        public RoleEnum Role { get; set; }
    }
}
