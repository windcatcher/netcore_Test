using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClient.ViewModel
{
    public class SkuViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int? ColorId { get; set; }
        public string Size { get; set; }
        public double? DeliveFee { get; set; }
        public double SkuPrice { get; set; }
        //库存
        public int StockInventory { get; set; }
        public int? SkuUpperLimit { get; set; }
        public string Location { get; set; }
        public string SkuImg { get; set; }
        public int? SkuSort { get; set; }
        public string SkuName { get; set; }
        public double? MarketPrice { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SkuType { get; set; }
        public int? Sales { get; set; }
    }
}
