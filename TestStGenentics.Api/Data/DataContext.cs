using Microsoft.EntityFrameworkCore;
using TestStGenentics.Shared.Entities;

namespace TestStGenentics.Api.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext>  options):base(options)
        {

        }
        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Animal>().HasIndex("Name", "Breed").IsUnique();
           
        }
    }
}
