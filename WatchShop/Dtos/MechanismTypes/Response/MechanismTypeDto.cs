using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.MechanismTypes.Response
{
    public class MechanismTypeDto
    {
        public byte Id { get; set; }

        public MechanismTypeEnum Name { get; set; }

        public string? Description { get; set; }
    }
}
