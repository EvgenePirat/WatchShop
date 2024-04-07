using WatchShop_Core.Models.Brends.Response;
using WatchShop_Core.Models.ClockFaces.Response;
using WatchShop_Core.Models.Countries.Response;
using WatchShop_Core.Models.Enums;
using WatchShop_Core.Models.Frames.Response;
using WatchShop_Core.Models.GlassTypes.Response;
using WatchShop_Core.Models.MechanismTypes.Response;
using WatchShop_Core.Models.Straps.Response;
using WatchShop_Core.Models.Styles.Response;
using WatchShop_Core.Models.WatchAdditionalCharacteristics.Response;

namespace WatchShop_Core.Models.Watches.Response
{
    public class WatchModel
    {
        public int Id { get; set; }

        public string NameModel { get; set; }

        public Gender Gender { get; set; }

        public GuaranteeMonth Guarantee { get; set; }

        public double Price { get; set; }

        public string? Description { get; set; }

        public TimeFormat TimeFormat { get; set; }

        public BrendModel Brend { get; set; }

        public StyleModel Style { get; set; }

        public StrapModel Strap { get; set; }

        public CountryModel Country { get; set; }

        public MechanismTypeModel MechanismType { get; set; }

        public GlassTypeModel GlassType { get; set; }

        public ClockFaceModel ClockFace { get; set; }

        public FrameModel? Frame { get; set; }

        public IEnumerable<WatchAdditionalCharacteristicModel>? WatchAdditionalCharacteristics { get; set; }
    }
}
