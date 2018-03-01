using System.ComponentModel.DataAnnotations;

namespace JwtAuth {
    public class LoginViewModel {
        [Required]
        public string User { get; set; }

        [Required]
        public string Pwd { get; set; }

    }
}