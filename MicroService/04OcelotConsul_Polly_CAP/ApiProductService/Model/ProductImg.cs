using System;
using System.Collections.Generic;

namespace ApiProductService
{
    public partial class ProductImg
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string Url { get; set; }
        public sbyte? IsDef { get; set; }

    }
}
