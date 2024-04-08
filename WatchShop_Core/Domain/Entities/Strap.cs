using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Contracts;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    [Table("straps")]
    public class Strap : IEntity
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public StrapEnum Name { get; set; }

        [Required]  
        public byte StrapMaterialId { get; set; }

        [ForeignKey("StrapMaterialId")]
        public StrapMaterial? StrapMaterial { get; set; }

        public IEnumerable<Watch>? Watches { get; set; }
    }
}
