namespace WatchShop_Core.Exceptions
{
    public class UserArgumentException : Exception
    {
        public UserArgumentException() : base() { }

        public UserArgumentException(string message) : base(message) { }

        public UserArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
