namespace WatchShop_Core.Exceptions
{
    public class BrendArgumentException : Exception
    {
        public BrendArgumentException() : base() { }

        public BrendArgumentException(string message) : base(message) { }

        public BrendArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
