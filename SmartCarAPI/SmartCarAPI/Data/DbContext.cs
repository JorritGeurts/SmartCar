using Microsoft.EntityFrameworkCore;
using SmartCarAPI.Models;

namespace SmartCarAPI.Data
{
    public class ApplicationDbContext :  DbContext
    {
        public ApplicationDbContext () { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Car> Car {  get; set; }
        public DbSet<Damage> Damage { get; set; }
        public DbSet<Severity> Severity { get; set; }
        public DbSet<CarSeverity> CarSeverity { get; set; }
    }
}
