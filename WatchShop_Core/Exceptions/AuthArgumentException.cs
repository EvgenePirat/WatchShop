namespace WatchShop_Core.Exceptions
{
    public class AuthArgumentException : Exception
    {
        public AuthArgumentException() : base() { }

        public AuthArgumentException(string message) : base(message) { }

        public AuthArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
