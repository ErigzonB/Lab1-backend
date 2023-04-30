using System.ComponentModel.DataAnnotations;

namespace SistemPerMenaxhiminESpitalit.Auth
{
    public class LoginModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}