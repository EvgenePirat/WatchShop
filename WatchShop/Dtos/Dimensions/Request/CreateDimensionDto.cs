using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.Dimensions.Request
{
    public class CreateDimensionDto
    {
        public double? Length { get; set; }

        public double? Thickness { get; set; }

        public double? Width { get; set; }

        public double? Weight { get; set; }

        public string CaseDiameter { get; set; }
    }
}
