using System;
using System.Collections.Generic;

namespace ApiProductService
{
    public  class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string WebSite { get; set; }
        public int? Sort { get; set; }
        public sbyte? IsDisplay { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
