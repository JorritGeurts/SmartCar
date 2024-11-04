using Microsoft.EntityFrameworkCore;
using SmartCarAPI.Models;

namespace SmartCarAPI.Data
{
    public class SmartCarContext :  DbContext
    {
        public SmartCarContext() { }

        public SmartCarContext(DbContextOptions<SmartCarContext> options) : base(options) { }

        public DbSet<Damage> Damage { get; set; }
    }
}
