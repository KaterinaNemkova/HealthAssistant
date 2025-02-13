using HealthAssistant.Infrastructure.Configurations;
using HealthAssistant.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace HealthAssistant.Infrastructure
{
    public class HealthAssistantDbContext : DbContext
    {
        public HealthAssistantDbContext(DbContextOptions<HealthAssistantDbContext> options):base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MealEntryProduct> EntriesProducts { get; set; }
        public DbSet<MealEntry> Meals {  get; set; }
        public DbSet<FoodTracker> FoodTrackers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FoodTrackerConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new MealEntryProductConfiguration());
            modelBuilder.ApplyConfiguration(new MealEntryConfiguration());

        }

    }
}
