using Microsoft.EntityFrameworkCore;
using SmartCarAPI.Models;

namespace SmartCarAPI.Data
{
    public class ApplicationDbContext :  DbContext
    {
        public ApplicationDbContext () { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Damage> Damage { get; set; }
    }
}
