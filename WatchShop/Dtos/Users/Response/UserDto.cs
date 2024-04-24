using WatchShop_Core.Models.Orders.Response;
using WatchShop_UI.Dtos.Orders.Response;

namespace WatchShop_UI.Dtos.Users.Response
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string UserName { get; set; }

        public string? Email { get; set; }

        public bool IsSubscriptionLetters { get; set; }

        public DateTime CreateAccountDate { get; set; }

        public IEnumerable<OrderDto?> Orders { get; set; }

        public string? City { get; set; }

        public string Role { get; set; }
    }
}
