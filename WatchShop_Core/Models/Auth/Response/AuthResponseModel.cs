namespace WatchShop_Core.Models.Auth.Response
{
    public class AuthResponseModel
    {
        public Guid UserId { get; set; }

        public string Username { get; set; }
        public string Token { get; set; }
    }
}
