namespace WatchShop_Core.Exceptions
{
    public class MessageArgumentException : Exception
    {
        public MessageArgumentException() : base() { }

        public MessageArgumentException(string message) : base(message) { }

        public MessageArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
