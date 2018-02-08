using System;
using System.Collections.Generic;

namespace DbFirst
{
    public partial class BbsColor
    {
        public BbsColor()
        {
            BbsSku = new HashSet<BbsSku>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string ImgUrl { get; set; }

        public ICollection<BbsSku> BbsSku { get; set; }
    }
}
