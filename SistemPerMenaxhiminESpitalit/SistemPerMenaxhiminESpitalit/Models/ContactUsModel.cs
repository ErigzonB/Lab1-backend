using System.ComponentModel.DataAnnotations;
namespace SistemPerMenaxhiminESpitalit.Models
{
    public class ContactUsModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string email { get; set; }
        [Required(ErrorMessage = "Message is required")]
        public string message { get; set; }
    }
}
