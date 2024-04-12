using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Enums;
using WatchShop_Core.Models.FrameMaterials.Response;
using WatchShop_Core.Models.FrameColors.Response;
using WatchShop_Core.Models.Dimensions.Response;

namespace WatchShop_Core.Models.Frames.Response
{
    public class FrameModel
    {
        public int Id { get; set; }

        public CaseShape CaseShape { get; set; }

        public WaterResistance WaterResistance { get; set; }

        public FrameMaterialModel? FrameMaterial { get; set; }

        public FrameColorModel? FrameColor { get; set; }

        public DimensionModel? Dimensions { get; set; }
    }
}
