using WatchShop_Core.Models.AdditionalCharacteristics.Response;
using WatchShop_Core.Models.Brends.Response;
using WatchShop_Core.Models.ClockFaceColors.Response;
using WatchShop_Core.Models.Countries.Response;
using WatchShop_Core.Models.Enums;
using WatchShop_Core.Models.FrameColors.Response;
using WatchShop_Core.Models.FrameMaterials.Response;
using WatchShop_Core.Models.GlassTypes.Response;
using WatchShop_Core.Models.IndicationKinds.Response;
using WatchShop_Core.Models.IndicationTypes.Response;
using WatchShop_Core.Models.MechanismTypes.Response;
using WatchShop_Core.Models.StrapMaterials.Response;
using WatchShop_Core.Models.Styles.Response;

namespace WatchShop_Core.Models.Watches.Response
{
    public class WatchCharactersModel
    {
        public IEnumerable<AdditionalCharacteristicModel> AdditionalCharacteristics { get; set; }

        public IEnumerable<StrapMaterialModel> StrapMaterials { get; set; }

        public string[] StrapEnums { get; } = Enum.GetNames<StrapEnum>();

        public string[] CaseDiameterEnums { get; set; } = Enum.GetNames<CaseDiameter>();

        public string[] CaseShapeEnums { get; set; } = Enum.GetNames<CaseShape>();

        public IEnumerable<ClockFaceColorModel> ClockFaceColors { get; set; }

        public IEnumerable<CountryModel> Countries { get; set; } 

        public IEnumerable<FrameColorModel> FrameColors { get; set; } 

        public IEnumerable<FrameMaterialModel> FrameMaterials { get; set; }

        public IEnumerable<BrendModel> Brends { get; set; }

        public string[] GenderEnums { get; set; } = Enum.GetNames<Gender>();

        public IEnumerable<GlassTypeModel> GlassTypes { get; set; }

        public string[] GuaranteeMonth { get; set; } = Enum.GetNames<GuaranteeMonth>();

        public IEnumerable<IndicationKindModel> IndicationKinds { get; set; }

        public IEnumerable<IndicationTypeModel> IndicationTypes { get; set; }

        public IEnumerable<MechanismTypeModel> MechanismTypes { get; set; }

        public IEnumerable<StyleModel> Styles { get; set; }

        public string[] TimeFormatEnums { get; set; } = Enum.GetNames<TimeFormat>();

        public string[] WaterResistanceEnums { get; set; } = Enum.GetNames<WaterResistance>();
    }
}
