using WatchShop_Core.Domain.Entities;
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
using WatchShop_Core.Models.StrapMaterials.Response;
using WatchShop_Core.Models.Straps.Response;
using WatchShop_Core.Models.Styles.Response;

namespace WatchShop_Core.Models.Watches.Response
{
    public class WatchCharactersModel
    {
        public IEnumerable<WatchShop_Core.Domain.Entities.AdditionalCharacteristics> AdditionalCharacteristics { get; set; }

        public IEnumerable<StrapMaterialModel> StrapMaterials { get; set; }

        public string[] StrapEnums { get; } = Enum.GetNames<StrapEnum>();

        public string[] CaseDiameters { get; set; } = Enum.GetNames<CaseDiameter>();

        public string[] CaseShapes { get; set; } = Enum.GetNames<CaseShape>();

        public IEnumerable<ClockFaceColor> ClockFaceColors { get; set; }

        public IEnumerable<Country> Countries { get; set; } 

        public IEnumerable<FrameColor> FrameColors { get; set; } 

        public IEnumerable<FrameMaterial> FrameMaterials { get; set; }

        public string[] GenderEnums { get; set; } = Enum.GetNames<Gender>();

        public IEnumerable<GlassType> GlassTypes { get; set; }

        public string[] GuaranteeMonth { get; set; } = Enum.GetNames<GuaranteeMonth>();

        public IEnumerable<IndicationKind> IndicationKinds { get; set; }

        public IEnumerable<IndicationType> IndicationTypes { get; set; }

        public IEnumerable<MechanismType> MechanismTypes { get; set; }

        public string[] Straps { get; set; } = Enum.GetNames<StrapEnum>();

        public IEnumerable<Style> Styles { get; set; }

        public string[] TimeFormatEnums { get; set; } = Enum.GetNames<TimeFormat>();

        public string[] WaterResistance { get; set; } = Enum.GetNames<WaterResistance>();
    }
}
