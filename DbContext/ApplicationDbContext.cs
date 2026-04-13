using Apartment_Project.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) :base(options){}

    public DbSet<Apartment> Apartments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed sample apartment data
        modelBuilder.Entity<Apartment>().HasData(
            new Apartment
            {
                ID = 1,
                Title = "Modern Downtown Studio",
                Location = "Downtown, New York",
                Description = "Beautiful studio apartment with floor-to-ceiling windows and modern amenities.",
                Price = 2500,
                IsAvailable = true
            },
            new Apartment
            {
                ID = 2,
                Title = "Cozy Brooklyn One Bedroom",
                Location = "Brooklyn, New York",
                Description = "Charming one-bedroom apartment with exposed brick and hardwood floors.",
                Price = 2800,
                IsAvailable = true
            },
            new Apartment
            {
                ID = 3,
                Title = "Luxury Manhattan Penthouse",
                Location = "Manhattan, New York",
                Description = "Stunning penthouse with panoramic city views and premium finishes.",
                Price = 5500,
                IsAvailable = false
            },
            new Apartment
            {
                ID = 4,
                Title = "Spacious Queens Family Home",
                Location = "Queens, New York",
                Description = "Large two-bedroom apartment perfect for families.",
                Price = 2200,
                IsAvailable = true
            },
            new Apartment
            {
                ID = 5,
                Title = "Riverside Apartment",
                Location = "Upper West Side, New York",
                Description = "Contemporary apartment with river views and modern kitchen.",
                Price = 3200,
                IsAvailable = true
            }
        );
    }
}

