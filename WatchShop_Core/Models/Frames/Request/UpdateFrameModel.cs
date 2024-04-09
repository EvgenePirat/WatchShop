using WatchShop_Core.Models.Dimensions.Request;
using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.Frames.Request
{
    public class UpdateFrameModel
    {
        public int Id { get; set; }

        public CaseShape CaseShape { get; set; }

        public WaterResistance WaterResistance { get; set; }

        public byte FrameMaterialId { get; set; }

        public byte FrameColorId { get; set; }

        public UpdateDimensionModel Dimensions { get; set; }
    }
}
