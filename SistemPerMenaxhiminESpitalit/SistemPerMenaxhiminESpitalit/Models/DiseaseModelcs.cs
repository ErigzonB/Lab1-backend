using System.ComponentModel.DataAnnotations;
namespace SistemPerMenaxhiminESpitalit.Models
{
    public class DiseaseModelcs
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
    }
}
