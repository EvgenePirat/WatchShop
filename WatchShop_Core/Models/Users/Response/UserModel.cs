namespace WatchShop_Core.Models.Users.Response
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string UserName { get; set; }

        public string? Email { get; set; }

        public DateTime CreateAccountDate { get; set; }

        public string? City { get; set; }

        public string Role { get; set; }
    }
}
