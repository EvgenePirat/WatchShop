namespace WatchShop_Core.Models.Comments.Request
{
    public class CreateCommentModel
    {
        public int WatchId { get; set; }

        public Guid UserId { get; set; }

        public string Comment { get; set; }

        public int Grade { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
