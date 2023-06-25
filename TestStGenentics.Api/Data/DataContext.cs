using Microsoft.EntityFrameworkCore;
using TestStGenentics.Shared.Entities;

namespace TestStGenentics.Api.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext>  options):base(options)
        {

        }
        public DbSet<Sex> Sexs { get; set; }
        public DbSet<StatusRow> StatusRows { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Animal> Animals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sex>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<StatusRow>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Breed>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Animal>().HasIndex(x => x.AnimalId).IsUnique();

        }
    }
}
