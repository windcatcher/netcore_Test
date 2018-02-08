using System;
using System.Collections.Generic;

namespace DbFirst
{
    public partial class BbsType
    {
        public BbsType()
        {
            BbsProduct = new HashSet<BbsProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string Note { get; set; }
        public sbyte IsDisplay { get; set; }

        public ICollection<BbsProduct> BbsProduct { get; set; }
    }
}
