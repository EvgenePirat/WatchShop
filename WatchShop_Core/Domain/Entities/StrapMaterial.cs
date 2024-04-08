using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Contracts;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    [Table("strap_materials")]
    public class StrapMaterial : IEntity
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public StrapMaterialEnum Name { get; set; }

        public IEnumerable<Strap>? Straps { get; set; }
    }
}
