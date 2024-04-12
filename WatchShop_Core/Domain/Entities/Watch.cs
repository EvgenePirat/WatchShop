using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Contracts;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Core.Domain.Entities
{
    [Index("NameModel", IsUnique = true)]
    [Table("watches")]
    public class Watch : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? NameModel { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public GuaranteeMonth Guarantee { get; set; }

        [Required]
        public double Price { get; set; }

        [MaxLength(500)]
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
        public int StrapId { get; set; }

        [ForeignKey("StrapId")]
        public Strap? Strap { get; set; }

        [Required]
        public byte CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country? Country { get; set; }

        [Required]
        public byte MechanismTypeId { get; set; }

        [ForeignKey("MechanismTypeId")]
        public MechanismType? MechanismType { get; set; }

        [Required]
        public byte GlassTypeId { get; set; }

        [ForeignKey("GlassTypeId")]
        public GlassType? GlassType { get; set; }

        [Required]
        public int ClockFaceId { get; set; }

        [ForeignKey("ClockFaceId")]
        public ClockFace? ClockFace { get; set; }

        public IEnumerable<WatchAdditionalCharacteristic>? WatchAdditionalCharacteristics { get; set; }

        [Required]
        public int FrameId { get; set; }

        [ForeignKey("FrameId")]
        public Frame? Frame { get; set; }

        [Required]
        public IEnumerable<Cart>? Carts { get; set; }

        public IEnumerable<WatchComment>? Comments { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}
