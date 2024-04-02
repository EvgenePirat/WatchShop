using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    public class StrapMaterial
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public StrapMaterialEnum Name { get; set; }
    }
}
