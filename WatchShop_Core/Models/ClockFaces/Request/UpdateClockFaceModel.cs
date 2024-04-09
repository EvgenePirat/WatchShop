namespace WatchShop_Core.Models.ClockFaces.Request
{
    public class UpdateClockFaceModel
    {
        public int Id { get; set; }

        public byte IndicationTypeId { get; set; }

        public byte IndicationKindId { get; set; }

        public byte ClockFaceColorId { get; set; }
    }
}
