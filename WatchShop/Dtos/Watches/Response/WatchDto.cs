﻿using System.Text.Json.Serialization;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Models.Images.Response;
using WatchShop_UI.Dtos.Brends.Response;
using WatchShop_UI.Dtos.ClockFaces.Response;
using WatchShop_UI.Dtos.Comments.Response;
using WatchShop_UI.Dtos.Countries.Response;
using WatchShop_UI.Dtos.Enums;
using WatchShop_UI.Dtos.Frames.Response;
using WatchShop_UI.Dtos.GlassTypes.Response;
using WatchShop_UI.Dtos.Images.Response;
using WatchShop_UI.Dtos.MechanismTypes.Response;
using WatchShop_UI.Dtos.Straps.Response;
using WatchShop_UI.Dtos.Styles.Response;
using WatchShop_UI.Dtos.WatchAdditionalCharacteristics.Response;

namespace WatchShop_UI.Dtos.Watches.Response
{
    public class WatchDto
    {
        public int Id { get; set; }
        public string NameModel { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public GuaranteeMonth Guarantee { get; set; }

        public double Price { get; set; }

        public bool IsDiscounted { get; set; } = false;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WatchState State { get; set; }

        public double? DiscountPrice { get; set; }

        public string? Description { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TimeFormat TimeFormat { get; set; }

        public BrendDto Brend { get; set; }

        public StyleDto Style { get; set; }

        public StrapDto Strap { get; set; }

        public CountryDto Country { get; set; }

        public MechanismTypeDto MechanismType { get; set; }

        public GlassTypeDto GlassType { get; set; }

        public ClockFaceDto ClockFace { get; set; }

        public FrameDto Frame { get; set; }

        public IEnumerable<WatchAdditionalCharacteristicDto>? WatchAdditionalCharacteristics { get; set; }

        public IEnumerable<ImageDto> Images { get; set; }

        public IEnumerable<CommentDto>? Comments { get; set; }
    }
}
