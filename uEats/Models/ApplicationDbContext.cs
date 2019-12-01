using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace uEats.Models
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Consumer> Consumers { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodRestaurant> FoodRestaurants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FoodRestaurant>().HasKey(sc => new
            {
                sc.FoodId,
                sc.RestaurantId
            });

            builder.Entity<FoodRestaurant>()
                .HasOne(foo => foo.Food)
                .WithMany(fr => fr.FoodRestaurants)
                .HasForeignKey(fo => fo.FoodId);
            
            builder.Entity<FoodRestaurant>()
                .HasOne(foo => foo.Restaurant)
                .WithMany(fr => fr.FoodRestaurants)
                .HasForeignKey(fo => fo.RestaurantId);
        }
    }
}