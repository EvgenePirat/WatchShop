using WatchShop_Core.Models.ClockFaces.Request;
using WatchShop_Core.Models.Enums;
using WatchShop_Core.Models.Frames.Request;
using WatchShop_Core.Models.Straps.Request;

namespace WatchShop_Core.Models.Watches.Request
{
    public class UpdateWatchModel
    {
        public string NameModel { get; set; }

        public Gender Gender { get; set; }

        public GuaranteeMonth Guarantee { get; set; }

        public double Price { get; set; }

        public string? Description { get; set; }

        public TimeFormat TimeFormat { get; set; }

        public int BrendId { get; set; }

        public byte StyleId { get; set; }

        public UpdateStrapModel? Strap { get; set; }

        public byte CountryId { get; set; }

        public byte MechanismTypeId { get; set; }

        public byte GlassTypeId { get; set; }

        public UpdateClockFaceModel ClockFace { get; set; }

        public UpdateFrameModel Frame { get; set; }
    }
}
