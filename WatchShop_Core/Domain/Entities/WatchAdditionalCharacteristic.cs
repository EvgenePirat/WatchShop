﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchShop_Core.Domain.Contracts;

namespace WatchShop_Core.Domain.Entities
{
    [Table("watch_additional_characteristics")]
    public class WatchAdditionalCharacteristic : IEntity
    {
        public int WatchId { get; set; }

        [ForeignKey("WatchId")]
        public Watch Watch { get; set; }

        public int AdditionalCharacteristicsId { get; set; }

        [ForeignKey("AdditionalCharacteristicsId")]
        public AdditionalCharacteristics AdditionalCharacteristics { get; set; }
    }
}
