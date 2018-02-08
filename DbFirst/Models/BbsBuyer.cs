using System;
using System.Collections.Generic;

namespace DbFirst
{
    public partial class BbsBuyer
    {
        public BbsBuyer()
        {
            BbsAddr = new HashSet<BbsAddr>();
            BbsOrder = new HashSet<BbsOrder>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string RealName { get; set; }
        public DateTime? RegisterTime { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string Addr { get; set; }
        public sbyte? IsDel { get; set; }

        public ICollection<BbsAddr> BbsAddr { get; set; }
        public ICollection<BbsOrder> BbsOrder { get; set; }
    }
}
