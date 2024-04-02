
using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    public class Style
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public StyleEnum? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
