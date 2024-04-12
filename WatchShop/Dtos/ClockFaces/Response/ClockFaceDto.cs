using WatchShop_UI.Dtos.ClockFaceColors.Response;
using WatchShop_UI.Dtos.IndicationKinds.Response;
using WatchShop_UI.Dtos.IndicationTypes.Response;

namespace WatchShop_UI.Dtos.ClockFaces.Response
{
    public class ClockFaceDto
    {
        public int Id { get; set; }

        public IndicationTypeDto IndicationType { get; set; }

        public IndicationKindDto IndicationKind { get; set; }

        public ClockFaceColorDto ClockFaceColor { get; set; }
    }
}
