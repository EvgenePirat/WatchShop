using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.ClockFaceColors.Response
{
    public class ClockFaceColorModel
    {
        public byte Id { get; set; }

        public ClockFaceColorEnum Name { get; set; }
    }
}
