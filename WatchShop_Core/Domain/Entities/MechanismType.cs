using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    [Table("mechanism_types")]
    public class MechanismType
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public MechanismTypeEnum Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public IEnumerable<Watch>? Watches { get; set; }
    }
}
