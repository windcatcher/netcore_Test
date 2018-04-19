using System;
using System.Collections.Generic;

namespace ApiOderService
{
    /// <summary>
    /// 订单子项
    /// </summary>
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductNo { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public double SkuPrice { get; set; }
        public int Amount { get; set; }

        //public Order Order { get; set; }
    }
}
