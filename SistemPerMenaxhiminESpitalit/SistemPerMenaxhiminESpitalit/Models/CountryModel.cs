using System.ComponentModel.DataAnnotations;
namespace SistemPerMenaxhiminESpitalit.Models
{
    public class CountryModel
    {
        [Required(ErrorMessage ="Name is required")]
        public string? Name { get; set; }
    }
}
