using SistemPerMenaxhiminESpitalit.Auth;

namespace SistemPerMenaxhiminESpitalit.Data
{
    public class Specialisation
    {
        public string? SpecialisationId { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<ApplicationUser> Users{ get; set; }
    }
}
