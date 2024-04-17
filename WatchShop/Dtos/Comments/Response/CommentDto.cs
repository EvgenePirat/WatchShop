namespace WatchShop_UI.Dtos.Comments.Response
{
    public class CommentDto
    {
        public Guid Id { get; set; }

        public int WatchId { get; set; }

        public Guid UserId { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
