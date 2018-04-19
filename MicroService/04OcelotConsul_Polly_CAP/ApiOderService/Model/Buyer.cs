using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiOderService
{

    public partial class Buyer
    {
        public Buyer()
        {
        }
        public int Id { get; set; }

        public string Username { get; set; }
        public string UserID { get; set; }
        public string Email { get; set; }
        public string RealName { get; set; }
        public string Addr { get; set; }

    }
}
