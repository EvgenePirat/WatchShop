using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Contracts;

namespace WatchShop_Core.Domain.Entities
{
    [Index("Name", IsUnique = true)]
    [Table("brends")]
    public class Brend : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public IEnumerable<Watch>? Watches { get; set; }
    }
}
