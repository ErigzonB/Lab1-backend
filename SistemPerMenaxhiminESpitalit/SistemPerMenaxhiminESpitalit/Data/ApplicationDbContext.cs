using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemPerMenaxhiminESpitalit.Auth;
using SistemPerMenaxhiminESpitalit.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Specialisation> specialisations { get; set; }
    public DbSet<Country> countries { get; set; }
    public DbSet<City> cities { get; set; }
    public DbSet<ContactUs> contactus { get; set; }   
    public DbSet<Appointment> appointment { get; set; } 
    public DbSet<Disease> diseases { get; set; }

    public DbSet<Drug>drugs { get; set; }    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}