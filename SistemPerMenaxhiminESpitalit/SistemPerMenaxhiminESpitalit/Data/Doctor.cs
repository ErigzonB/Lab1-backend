using System.ComponentModel.DataAnnotations;

namespace SistemPerMenaxhiminESpitalit.Data
{
    internal sealed class Doctor
    {
        [Key]   
        public int DoctorID{ get; set; }
        
        [Required]
        [MaxLength(length:40)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(length:40)]
        public string Surname { get; set; }= string.Empty;
        
        [Required]
        [MaxLength(length:40)]
        public string Email { get; set; }= string.Empty;
        
        [Required]
        [MaxLength(length:40)]
        public string Password { get; set; }= string.Empty;
       
        [Required]
        [MaxLength(length:80)]
        public string Address { get; set; }= string.Empty;
        
        [Required]
        [MaxLength(length:20)]
        public string Specialisation { get; set; }= string.Empty;

        [Required]
        public char Gender { get; set; }

        [Required]
        [MaxLength(length: 20)]
        public string State { get; set; } = string.Empty;

        [Required]
        [MaxLength(length: 20)]
        public string City { get; set; } = string.Empty;

        [Required]
        public int Zip { get; set; }


    }
}
