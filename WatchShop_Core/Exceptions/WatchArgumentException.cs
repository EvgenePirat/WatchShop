namespace WatchShop_Core.Exceptions
{
    public class WatchArgumentException : Exception
    {
        public WatchArgumentException() : base() { }

        public WatchArgumentException(string message) : base(message) { }

        public WatchArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
