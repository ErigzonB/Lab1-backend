using System.ComponentModel.DataAnnotations;

namespace SistemPerMenaxhiminESpitalit.Models
{
    public class UpdatePatientModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }
    }
}
