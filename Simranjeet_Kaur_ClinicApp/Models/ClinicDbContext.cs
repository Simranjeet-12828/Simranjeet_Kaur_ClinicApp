using Microsoft.EntityFrameworkCore;

namespace Simranjeet_Kaur_ClinicApp.Models
{
    public class ClinicDBContext : DbContext
    {
        public ClinicDBContext(DbContextOptions<ClinicDBContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
    }

}
