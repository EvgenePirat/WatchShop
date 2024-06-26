﻿using System.Text.Json.Serialization;
using WatchShop_UI.Dtos.Enums;

namespace WatchShop_UI.Dtos.GlassTypes.Response
{
    public class GlassTypeDto
    {
        public byte Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public GlassTypeEnum Name { get; set; }

        public string? Description { get; set; }
    }
}
