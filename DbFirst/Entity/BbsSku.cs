using System;
using System.Collections.Generic;

namespace DbFirst
{
    public partial class BbsSku
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int? ColorId { get; set; }
        public string Size { get; set; }
        public double? DeliveFee { get; set; }
        public double SkuPrice { get; set; }
        public int StockInventory { get; set; }
        public int? SkuUpperLimit { get; set; }
        public string Location { get; set; }
        public string SkuImg { get; set; }
        public int? SkuSort { get; set; }
        public string SkuName { get; set; }
        public double? MarketPrice { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string CreateUserId { get; set; }
        public string UpdateUserId { get; set; }
        public int? LastStatus { get; set; }
        public int? SkuType { get; set; }
        public int? Sales { get; set; }

        public BbsColor Color { get; set; }
        public BbsProduct Product { get; set; }
    }
}
