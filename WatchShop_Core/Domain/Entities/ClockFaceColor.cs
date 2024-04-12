using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Contracts;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    [Table("clock_face_colors")]
    public class ClockFaceColor : IEntity
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public ClockFaceColorEnum Name { get; set; }

        public IEnumerable<ClockFace>? ClockFaces { get; set; }
    }
}
