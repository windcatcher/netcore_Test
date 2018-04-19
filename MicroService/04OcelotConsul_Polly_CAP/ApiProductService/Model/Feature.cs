using System;
using System.Collections.Generic;

namespace ApiProductService
{
    public partial class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int? Sort { get; set; }
        public sbyte? IsDel { get; set; }
    }
}
