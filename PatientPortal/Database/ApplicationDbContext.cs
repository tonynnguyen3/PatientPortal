namespace PatientPortal.Database
{
    using Microsoft.EntityFrameworkCore;
    public class ApplicationDbContext : DbContext
    {
        //Generating an DbContextOptions, by calling it super constructor method
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Patient> Patients { get; set; }
    }
}
