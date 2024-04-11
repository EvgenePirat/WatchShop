namespace WatchShop_Core.Exceptions
{
    public class OrderArgumentException : Exception
    {
        public OrderArgumentException() : base() { }

        public OrderArgumentException(string message) : base(message) { }

        public OrderArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
