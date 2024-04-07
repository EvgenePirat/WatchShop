﻿using WatchShop_Core.Models.Enums;

namespace WatchShop_Core.Models.Dimensions.Response
{
    public class DimensionModel
    {
        public int Id { get; set; }

        public double? Length { get; set; }

        public double? Thickness { get; set; }

        public double? Width { get; set; }

        public double? Weight { get; set; }

        public CaseDiameter CaseDiameter { get; set; }
    }
}
