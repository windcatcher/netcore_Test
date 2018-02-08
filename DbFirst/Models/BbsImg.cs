using System;
using System.Collections.Generic;

namespace DbFirst
{
    public partial class BbsImg
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string Url { get; set; }
        public sbyte? IsDef { get; set; }

        public BbsProduct Product { get; set; }
    }
}
