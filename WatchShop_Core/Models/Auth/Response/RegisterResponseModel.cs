namespace WatchShop_Core.Models.Auth.Response
{
    public class RegisterResponseModel
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}
