using System;
using System.Collections.Generic;

namespace CodeFirstEcom
{
    public partial class BbsBrand
    {
        public BbsBrand()
        {
            BbsProduct = new HashSet<BbsProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string WebSite { get; set; }
        public int? Sort { get; set; }
        public sbyte? IsDisplay { get; set; }

        public ICollection<BbsProduct> BbsProduct { get; set; }
    }
}
