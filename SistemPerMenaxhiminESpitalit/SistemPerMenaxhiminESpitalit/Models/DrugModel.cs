using System.ComponentModel.DataAnnotations;
namespace SistemPerMenaxhiminESpitalit.Models
{
    public class DrugModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Data is required")]
        public string? Date { get; set; }
    }
}
