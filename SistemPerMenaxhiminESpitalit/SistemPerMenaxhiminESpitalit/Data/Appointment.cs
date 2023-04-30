using SistemPerMenaxhiminESpitalit.Auth;
namespace SistemPerMenaxhiminESpitalit.Data
{
    public class Appointment
    {
        public Appointment()
        {
            this.Users = new HashSet<ApplicationUser>();
        }
        public string? AppointmentID { get; set; }
        public string? Description { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; } 
    }
}
