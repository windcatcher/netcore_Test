using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class LoginInputModel
    {
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
        [Required]
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}
