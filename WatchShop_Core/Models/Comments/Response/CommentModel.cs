namespace WatchShop_Core.Models.Comments.Response
{
    public class CommentModel
    {
        public Guid Id { get; set; }

        public int WatchId { get; set; }

        public Guid UserId { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
