using Microsoft.EntityFrameworkCore;
using CodetestBF.WebApi.Models;

namespace CodetestBF.WebApi.Data;

public class CodetestBFDb : DbContext
{
    public DbSet<Brand> brands { get; set; }
    public DbSet<VehicleFeature>? features { get; set; }
    public DbSet<Vehicle>? vehicles { get; set; }

    public CodetestBFDb(DbContextOptions<CodetestBFDb> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Brand b1 = new() { Id = 1, Name = "Ford" };
        Brand b2 = new() { Id = 2, Name = "BMW" };
        Brand b3 = new() { Id = 3, Name = "Volvo"};

        modelBuilder.Entity<Brand>().HasData(b1, b2, b3);
    }
}