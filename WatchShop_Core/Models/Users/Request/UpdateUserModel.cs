using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Models.Users.Request
{
    public class UpdateUserModel
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string UserName { get; set; }

        public string? Email { get; set; }

        public string? City { get; set; }

        public RoleEnum Role { get; set; }
    }
}
