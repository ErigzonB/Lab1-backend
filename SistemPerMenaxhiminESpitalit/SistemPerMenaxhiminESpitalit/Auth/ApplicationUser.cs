using Microsoft.AspNetCore.Identity;
using SistemPerMenaxhiminESpitalit.Data;

namespace SistemPerMenaxhiminESpitalit.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.appointments = new HashSet<Appointment>(); 
        }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public string? SpecialisationId { get; set; }
        public Specialisation Specialisation { get; set; }
        public string? CountryId { get; set; }
        public Country Country { get; set; }

        public virtual ICollection<Appointment> appointments { get; set; }
    }
}
