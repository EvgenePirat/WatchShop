using System.Text.Json.Serialization;
using WatchShop_Core.Models.Dimensions.Response;
using WatchShop_Core.Models.FrameColors.Response;
using WatchShop_Core.Models.FrameMaterials.Response;
using WatchShop_UI.Dtos.Dimensions.Response;
using WatchShop_UI.Dtos.Enums;
using WatchShop_UI.Dtos.FrameColors.Response;
using WatchShop_UI.Dtos.FrameMaterials.Response;

namespace WatchShop_UI.Dtos.Frames.Response
{
    public class FrameDto
    {
        public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CaseShape CaseShape { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WaterResistance WaterResistance { get; set; }

        public FrameMaterialDto? FrameMaterial { get; set; }

        public FrameColorDto? FrameColor { get; set; }

        public DimensionDto? Dimensions { get; set; }
    }
}
