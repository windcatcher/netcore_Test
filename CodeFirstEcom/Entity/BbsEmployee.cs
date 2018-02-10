using System;
using System.Collections.Generic;

namespace CodeFirstEcom
{
    public partial class BbsEmployee
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Degree { get; set; }
        public string Email { get; set; }
        public sbyte? Gender { get; set; }
        public string ImgUrl { get; set; }
        public string Phone { get; set; }
        public string RealName { get; set; }
        public string School { get; set; }
        public sbyte IsDel { get; set; }
        public int Id { get; set; }
    }
}
