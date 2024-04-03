using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Entities.Identities;

namespace WatchShop_Core.Domain.Entities
{
    [Table("watch_comments")]
    public class WatchComment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int WatchId { get; set; }

        [ForeignKey("WatchId")]
        public Watch? Watch { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        [MaxLength(200)]
        [Required]
        public string? Comment { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
