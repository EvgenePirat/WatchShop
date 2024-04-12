using WatchShop_Core.Models.Brends.Response;
using WatchShop_UI.Dtos.AdditionalCharacteristics.Response;
using WatchShop_UI.Dtos.Brends.Response;
using WatchShop_UI.Dtos.ClockFaceColors.Response;
using WatchShop_UI.Dtos.Countries.Response;
using WatchShop_UI.Dtos.Enums;
using WatchShop_UI.Dtos.FrameColors.Response;
using WatchShop_UI.Dtos.FrameMaterials.Response;
using WatchShop_UI.Dtos.GlassTypes.Response;
using WatchShop_UI.Dtos.IndicationKinds.Response;
using WatchShop_UI.Dtos.IndicationTypes.Response;
using WatchShop_UI.Dtos.MechanismTypes.Response;
using WatchShop_UI.Dtos.StrapMaterials.Response;
using WatchShop_UI.Dtos.Styles.Response;

namespace WatchShop_UI.Dtos.Products.Response
{
    public class WatchCharactersDto
    {
        public IEnumerable<AdditionalCharacteristicDto> AdditionalCharacteristics { get; set; }

        public IEnumerable<StrapMaterialDto> StrapMaterials { get; set; }

        public string[] StrapEnums { get; } = Enum.GetNames<StrapEnum>();

        public string[] CaseDiameterEnums { get; set; } = Enum.GetNames<CaseDiameter>();

        public string[] CaseShapeEnums { get; set; } = Enum.GetNames<CaseShape>();

        public IEnumerable<ClockFaceColorDto> ClockFaceColors { get; set; }

        public IEnumerable<BrendDto> Brends { get; set; }

        public IEnumerable<CountryDto> Countries { get; set; }

        public IEnumerable<FrameColorDto> FrameColors { get; set; }

        public IEnumerable<FrameMaterialDto> FrameMaterials { get; set; }

        public string[] GenderEnums { get; set; } = Enum.GetNames<Gender>();

        public IEnumerable<GlassTypeDto> GlassTypes { get; set; }

        public string[] GuaranteeMonth { get; set; } = Enum.GetNames<GuaranteeMonth>();

        public IEnumerable<IndicationKindDto> IndicationKinds { get; set; }

        public IEnumerable<IndicationTypeDto> IndicationTypes { get; set; }

        public IEnumerable<MechanismTypeDto> MechanismTypes { get; set; }

        public IEnumerable<StyleDto> Styles { get; set; }

        public string[] TimeFormatEnums { get; set; } = Enum.GetNames<TimeFormat>();

        public string[] WaterResistanceEnums { get; set; } = Enum.GetNames<WaterResistance>();
    }
}
