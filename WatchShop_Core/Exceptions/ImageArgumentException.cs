namespace WatchShop_Core.Exceptions
{
    public class ImageArgumentException : Exception
    {
        public ImageArgumentException() : base() { }

        public ImageArgumentException(string message) : base(message) { }

        public ImageArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
