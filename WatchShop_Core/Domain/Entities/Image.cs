using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Contracts;

namespace WatchShop_Core.Domain.Entities
{
    [Table("images")]
    public class Image : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Path { get; set; }

        public DateTime UploadDateTime { get; set; }

        [Required]
        public int WatchId { get; set; }

        [ForeignKey("WatchId")]
        public Watch Watch { get; set; }
    }
}
