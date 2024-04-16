namespace WatchShop_Core.Exceptions
{
    public class CommentWatchArgumentException : Exception
    {
        public CommentWatchArgumentException() : base() { }

        public CommentWatchArgumentException(string message) : base(message) { }

        public CommentWatchArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
