using WatchShop_Core.Models.Dimensions.Request;
using WatchShop_UI.Dtos.Dimensions.Request;
using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.Frames.Request
{
    public class CreateFrameDto
    {
        public string CaseShape { get; set; }

        public string WaterResistance { get; set; }

        public byte FrameMaterialId { get; set; }

        public byte FrameColorId { get; set; }

        public CreateDimensionDto Dimensions { get; set; }
    }
}
