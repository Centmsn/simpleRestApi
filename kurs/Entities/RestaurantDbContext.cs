using Microsoft.EntityFrameworkCore;

namespace kurs.Entities
{
    public class RestaurantDbContext : DbContext
    {
        private string _conntectionString = "Server=(localdb)\\mssqllocaldb;Database=RestaurantDb;Trusted_Connection=True;";
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Address { get; set; } 
        public DbSet<Dish> Dish { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conntectionString);
        }
    }
}
