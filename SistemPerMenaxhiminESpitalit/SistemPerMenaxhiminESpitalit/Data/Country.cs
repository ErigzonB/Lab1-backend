using SistemPerMenaxhiminESpitalit.Auth;

namespace SistemPerMenaxhiminESpitalit.Data
{
    public class Country
    {
        public string? CountryId { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
