using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.IndicationTypes.Response
{
    public class IndicationTypeDto
    {
        public byte Id { get; set; }

        public IndicationTypeEnum Name { get; set; }
    }
}
