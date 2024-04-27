﻿namespace WatchShop_Core.Models.SalesStatistics.Response
{
    public class SalesStatisticModel
    {
        public int TotalSales { get; set; } 
        public double TotalRevenue { get; set; }
        public double AverageOrderValue { get; set; }
        public int TotalOrdersInProgress { get; set; }
        public int TotalOrdersInCreate { get; set; }
        public int DaysAgo { get; set; }
        public Dictionary<DateTime, int> SalesByDay { get; set; }
    }
}
