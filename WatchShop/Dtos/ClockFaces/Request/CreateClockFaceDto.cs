namespace WatchShop_UI.Dtos.ClockFaces.Request
{
    public class CreateClockFaceDto
    {
        public byte IndicationTypeId { get; set; }

        public byte IndicationKindId { get; set; }

        public byte ClockFaceColorId { get; set; }
    }
}
