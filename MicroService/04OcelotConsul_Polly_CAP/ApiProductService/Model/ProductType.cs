using System;
using System.Collections.Generic;

namespace ApiProductService
{
    public partial class ProductType
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string Note { get; set; }
        public sbyte IsDisplay { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
