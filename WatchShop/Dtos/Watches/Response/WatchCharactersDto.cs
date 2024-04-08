using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.Products.Response
{
    public class WatchCharactersDto
    {
        public string[] AdditionalCharacteristicsEnum { get; } = Enum.GetNames<AdditionalCharacteristicsEnum>();

        public string[] CaseDiameter { get; } = Enum.GetNames<CaseDiameter>();

        public string[] CaseShape { get;  } = Enum.GetNames<CaseShape>();

        public string[] ClockFaceColorEnum { get;  } = Enum.GetNames<ClockFaceColorEnum>();

        public string[] CountryEnum { get; } = Enum.GetNames<CountryEnum>();

        public string[] FrameColorEnum { get;} = Enum.GetNames<FrameColorEnum>();

        public string[] FrameMaterialEnum { get;} = Enum.GetNames<FrameMaterialEnum>();

        public string[] Gender { get; } = Enum.GetNames<Gender>();

        public string[] GlassTypeEnum { get; } = Enum.GetNames<GlassTypeEnum>();

        public string[] GuaranteeMonth { get; } = Enum.GetNames<GuaranteeMonth>();

        public string[] IndicationKindEnum { get; } = Enum.GetNames<IndicationKindEnum>();

        public string[] IndicationTypeEnum { get; } = Enum.GetNames<IndicationTypeEnum>();

        public string[] MechanismTypeEnum { get; } = Enum.GetNames<MechanismTypeEnum>();

        public string[] StrapEnum { get; } = Enum.GetNames<StrapEnum>();

        public string[] StrapMaterialEnum { get; } = Enum.GetNames<StrapMaterialEnum>();

        public string[] StyleEnum { get; } = Enum.GetNames<StyleEnum>();

        public string[] TimeFormat { get; } = Enum.GetNames<TimeFormat>();

        public string[] WaterResistance { get; } = Enum.GetNames<WaterResistance>();
    }
}
