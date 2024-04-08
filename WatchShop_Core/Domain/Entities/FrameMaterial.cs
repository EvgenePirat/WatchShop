using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Contracts;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    [Table("frame_materials")]
    public class FrameMaterial : IEntity
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public FrameMaterialEnum Name { get; set; }

        public IEnumerable<Frame>? Frames { get; set; }
    }
}
