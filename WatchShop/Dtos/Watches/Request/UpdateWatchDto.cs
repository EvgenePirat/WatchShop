using WatchShop_Core.Models.ClockFaces.Request;
using WatchShop_Core.Models.Frames.Request;
using WatchShop_Core.Models.Straps.Request;
using WatchShop_UI.Dtos.ClockFaces.Request;
using WatchShop_UI.Dtos.Enums;
using WatchShop_UI.Dtos.Frames.Request;
using WatchShop_UI.Dtos.Straps.Request;

namespace WatchShop_UI.Dtos.Watches.Request
{
    public class UpdateWatchDto
    {
        public string NameModel { get; set; }

        public string Gender { get; set; }

        public string Guarantee { get; set; }

        public double Price { get; set; }

        public string? Description { get; set; }

        public string TimeFormat { get; set; }

        public int BrendId { get; set; }

        public byte StyleId { get; set; }

        public UpdateStrapDto? Strap { get; set; }

        public byte CountryId { get; set; }

        public byte MechanismTypeId { get; set; }

        public byte GlassTypeId { get; set; }

        public UpdateClockFaceDto ClockFace { get; set; }

        public UpdateFrameDto Frame { get; set; }
    }
}
