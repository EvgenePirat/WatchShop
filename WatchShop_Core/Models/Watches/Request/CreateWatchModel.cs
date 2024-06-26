﻿using Microsoft.AspNetCore.Http;
using WatchShop_Core.Models.ClockFaces.Request;
using WatchShop_Core.Models.Enums;
using WatchShop_Core.Models.Frames.Request;
using WatchShop_Core.Models.Straps.Request;
using WatchShop_Core.Models.WatchAdditionalCharacteristics.Request;

namespace WatchShop_Core.Models.Watches.Request
{
    public class CreateWatchModel
    {
        public string NameModel { get; set; }

        public Gender Gender { get; set; }

        public GuaranteeMonth Guarantee { get; set; }

        public double Price { get; set; }

        public string? Description { get; set; }

        public TimeFormat TimeFormat { get; set; }

        public int BrendId { get; set; }

        public byte StyleId { get; set; }

        public bool IsDiscounted { get; set; } = false;

        public WatchState State { get; set; }

        public double? DiscountPrice { get; set; }

        public CreateStrapModel Strap { get; set; }

        public byte CountryId { get; set; }

        public byte MechanismTypeId { get; set; }

        public byte GlassTypeId { get; set; }

        public CreateClockFaceModel ClockFace { get; set; }

        public CreateFrameModel Frame { get; set; }

        public List<int> WatchAdditionalCharacteristicsList { get; set; }

        public IFormFile[] Files { get; set; }
    }
}
