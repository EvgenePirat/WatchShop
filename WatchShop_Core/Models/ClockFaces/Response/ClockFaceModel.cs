using WatchShop_Core.Models.ClockFaceColors.Response;
using WatchShop_Core.Models.IndicationKinds.Request;
using WatchShop_Core.Models.IndicationTypes.Response;

namespace WatchShop_Core.Models.ClockFaces.Response
{
    public class ClockFaceModel
    {
        public int Id { get; set; }

        public IndicationTypeModel? IndicationType { get; set; }

        public IndicationKindModel? IndicationKind { get; set; }

        public ClockFaceColorModel? ClockFaceColor { get; set; }
    }
}
