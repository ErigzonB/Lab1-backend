using System.ComponentModel.DataAnnotations;

namespace SistemPerMenaxhiminESpitalit.Models
{
    public class UpdateDoctorModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        public string? Surname { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Specialisation is required")]
        public string? Specialisationid { get; set; }
        

    }
}
