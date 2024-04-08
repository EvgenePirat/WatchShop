using WatchShop_Core.Models.AdditionalCharacteristics.Response;
using WatchShop_Core.Models.ClockFaceColors.Response;
using WatchShop_Core.Models.Countries.Response;
using WatchShop_Core.Models.Enums;
using WatchShop_Core.Models.FrameColors.Response;
using WatchShop_Core.Models.FrameMaterials.Response;
using WatchShop_Core.Models.GlassTypes.Response;
using WatchShop_Core.Models.IndicationKinds.Response;
using WatchShop_Core.Models.IndicationTypes.Response;
using WatchShop_Core.Models.MechanismTypes.Response;
using WatchShop_Core.Models.Straps.Response;
using WatchShop_Core.Models.Styles.Response;

namespace WatchShop_Core.Models.Watches.Response
{
    public class WatchCharactersModel
    {
        public List<AdditionalCharacteristicModel> AdditionalCharacteristics { get; set; }

        public string[] CaseDiameters { get; set; } = Enum.GetNames<CaseDiameter>();

        public string[] CaseShapes { get; set; } = Enum.GetNames<CaseShape>();

        public List<ClockFaceColorModel> ClockFaceColors { get; set; }

        public List<CountryModel> Countries { get; set; } 

        public List<FrameColorModel> FrameColors { get; set; } 

        public List<FrameMaterialModel> FrameMaterials { get; set; }

        public string[] Gender { get; set; } = Enum.GetNames<Gender>();

        public List<GlassTypeModel> GlassTypeEnum { get; set; }

        public string[] GuaranteeMonth { get; set; } = Enum.GetNames<GuaranteeMonth>();

        public List<IndicationKindModel> IndicationKinds { get; set; }

        public List<IndicationTypeModel> IndicationTypes { get; set; }

        public List<MechanismTypeModel> MechanismTypes { get; set; }

        public List<StrapModel> Straps { get; set; } 

        public List<StyleModel> Styles { get; set; }

        public string[] TimeFormatEnums { get; set; } = Enum.GetNames<TimeFormat>();

        public string[] WaterResistance { get; set; } = Enum.GetNames<WaterResistance>();
    }
}
