using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    [Index("NameModel", IsUnique = true)]
    public class Watch
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? NameModel { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public GuaranteeMonth Guarantee { get; set; }

        [Required]
        public double Price { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public TimeFormat TimeFormat { get; set; }

        [Required]
        public int BrendId { get; set; }

        [ForeignKey("BrendId")]
        public Brend? Brend { get; set; }

        [Required]
        public byte StyleId { get; set; }

        [ForeignKey("StyleId")]
        public Style? Style { get; set; }

        [Required]
        public byte StrapId { get; set; }

        [ForeignKey("StrapId")]
        public Strap? Strap { get; set; }

        [Required]
        public byte CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country? Country { get; set; }

        [Required]
        public byte MechanismTypeId { get; set; }

        [ForeignKey("MechanismType")]
        public MechanismType? MechanismType { get; set; }

    }
}
