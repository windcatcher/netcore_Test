using System;
using System.Collections.Generic;

namespace DbFirst
{
    public partial class BbsProduct
    {
        public BbsProduct()
        {
            BbsImg = new HashSet<BbsImg>();
            BbsSku = new HashSet<BbsSku>();
        }

        public int Id { get; set; }
        public string No { get; set; }
        public string Name { get; set; }
        public double? Weight { get; set; }
        public sbyte? IsNew { get; set; }
        public sbyte? IsHot { get; set; }
        public sbyte? IsCommend { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? CheckTime { get; set; }
        public string CheckUserId { get; set; }
        public sbyte? IsShow { get; set; }
        public sbyte? IsDel { get; set; }
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public string Keywords { get; set; }
        public int? Sales { get; set; }
        public string Description { get; set; }
        public string PackageList { get; set; }
        public string Feature { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }

        public BbsBrand Brand { get; set; }
        public BbsType Type { get; set; }
        public ICollection<BbsImg> BbsImg { get; set; }
        public ICollection<BbsSku> BbsSku { get; set; }
    }
}
