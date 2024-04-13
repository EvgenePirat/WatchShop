using WatchShop_UI.Dtos.ClockFaces.Request;
using WatchShop_UI.Dtos.Enums;
using WatchShop_UI.Dtos.Frames.Request;
using WatchShop_UI.Dtos.Straps.Request;
using WatchShop_UI.Dtos.WatchAdditionalCharacteristics.Request;
using WatchShop_UI.Dtos.WatchAdditionalCharacteristics.Response;

namespace WatchShop_UI.Dtos.Watches.Request
{
    public class CreateWatchDto
    {
        public string NameModel { get; set; }

        public string Gender { get; set; }

        public string Guarantee { get; set; }

        public double Price { get; set; }

        public string? Description { get; set; }

        public string TimeFormat { get; set; }

        public int BrendId { get; set; }

        public byte StyleId { get; set; }

        public CreateStrapDto? Strap { get; set; }

        public byte CountryId { get; set; }

        public byte MechanismTypeId { get; set; }

        public byte GlassTypeId { get; set; }

        public CreateClockFaceDto ClockFace { get; set; }

        public CreateFrameDto? Frame { get; set; }

        public List<IFormFile> Files { get; set; }

        public List<int> WatchAdditionalCharacteristicsList { get; set; }
    }
}
