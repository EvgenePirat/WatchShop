using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.Dimensions.Response
{
    public class DimensionDto
    {
        public int Id { get; set; }

        public double? Length { get; set; }

        public double? Thickness { get; set; }

        public double? Width { get; set; }

        public double? Weight { get; set; }

        public CaseDiameter CaseDiameter { get; set; }
    }
}
