using Microsoft.EntityFrameworkCore;
using WebAppShiba.Models;

namespace WebAppShiba.DataBase
{
    public class ShibaContext:DbContext
    {

        public DbSet<Shiba> Url { get; set; }

        public ShibaContext(DbContextOptions<ShibaContext> options) : base(options)
        {

        }

        public static ShibaContext CallShibaContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShibaContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=Shiba;Trusted_Connection=True;MultipleActiveResultSets=true");
            var db = new ShibaContext(optionsBuilder.Options);
            return db;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shiba>().ToTable("Url");
        }

    }
}
