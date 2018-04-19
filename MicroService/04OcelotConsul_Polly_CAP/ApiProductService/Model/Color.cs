using System;
using System.Collections.Generic;

namespace ApiProductService
{
    public partial class Color
    {
        public Color()
        {
            Skus = new HashSet<Sku>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string ImgUrl { get; set; }

        public ICollection<Sku> Skus { get; set; }
    }
}
