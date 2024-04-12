namespace WatchShop_UI.Dtos.ClockFaces.Request
{
    public class UpdateClockFaceDto
    {
        public int Id { get; set; }

        public byte IndicationTypeId { get; set; }

        public byte IndicationKindId { get; set; }

        public byte ClockFaceColorId { get; set; }
    }
}
