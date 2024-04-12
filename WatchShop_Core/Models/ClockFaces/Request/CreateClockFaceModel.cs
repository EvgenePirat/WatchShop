namespace WatchShop_Core.Models.ClockFaces.Request
{
    public class CreateClockFaceModel
    {
        public byte IndicationTypeId { get; set; }

        public byte IndicationKindId { get; set; }

        public byte ClockFaceColorId { get; set; }
    }
}
