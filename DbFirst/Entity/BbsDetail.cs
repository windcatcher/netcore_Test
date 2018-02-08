using System;
using System.Collections.Generic;

namespace DbFirst
{
    public partial class BbsDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductNo { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public double SkuPrice { get; set; }
        public int Amount { get; set; }

        public BbsOrder Order { get; set; }
    }
}
