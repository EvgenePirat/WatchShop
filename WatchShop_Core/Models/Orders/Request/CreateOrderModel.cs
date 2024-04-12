﻿using WatchShop_Core.Models.Carts.Request;

namespace WatchShop_Core.Models.Orders.Request
{
    public class CreateOrderModel
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public double Sum { get; set; }

        public Guid UserId { get; set; }

        public byte OrderStatusId { get; set; }

        public IEnumerable<CreateCartModel> Carts { get; set; }

        public string? Comment { get; set; }
    }
}
