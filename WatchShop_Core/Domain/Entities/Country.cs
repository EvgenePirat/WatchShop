using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    [Table("countries")]
    public class Country
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public CountryEnum Name { get; set; }

        public IEnumerable<Watch>? Watches { get; set; }
    }
}
