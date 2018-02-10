using System;
using System.Collections.Generic;

namespace CodeFirstEcom
{
    public partial class BbsAddr
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Addr { get; set; }
        public string Phone { get; set; }
        public int IsDef { get; set; }

        public BbsBuyer Buyer { get; set; }
    }
}
