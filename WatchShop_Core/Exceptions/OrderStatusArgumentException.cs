namespace WatchShop_Core.Exceptions
{
    public class OrderStatusArgumentException : Exception
    {
        public OrderStatusArgumentException() : base() { }

        public OrderStatusArgumentException(string message) : base(message) { }

        public OrderStatusArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
