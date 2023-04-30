using System.ComponentModel.DataAnnotations;
namespace SistemPerMenaxhiminESpitalit.Models
{
    public class CityModel
    {
        [Required(ErrorMessage ="Name is required")]
        public string? Name { get; set; }
    }
}
