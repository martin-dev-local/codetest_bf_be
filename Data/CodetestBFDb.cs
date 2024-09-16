using Microsoft.EntityFrameworkCore;
using CodetestBF.WebApi.Models;

namespace CodetestBF.WebApi.Data;

public class CodetestBFDb : DbContext
{
    public DbSet<Brand> brands { get; set; }
    public DbSet<VehicleFeature> features { get; set; }
    public DbSet<Vehicle> vehicles { get; set; }

    public CodetestBFDb(DbContextOptions<CodetestBFDb> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        Brand b1 = new() { Id = 1, Name = "Ford" };
        Brand b2 = new() { Id = 2, Name = "BMW" };
        Brand b3 = new() { Id = 3, Name = "Volvo"};

        modelBuilder.Entity<Brand>().HasData(b1, b2, b3);

        VehicleFeature f1 = new() { Id = 1, Name = "Leather seats" };
        VehicleFeature f2 = new() { Id = 2, Name = "Parking sensor" };
        VehicleFeature f3 = new() { Id = 3, Name = "Xenon lights" };
        VehicleFeature f4 = new() { Id = 4, Name = "Rear view camera" };
        VehicleFeature f5 = new() { Id = 5, Name = "Sun roof" };
        VehicleFeature f6 = new() { Id = 6, Name = "Bose sound system"};

        modelBuilder.Entity<VehicleFeature>().HasData(f1, f2, f3, f4, f5, f6);

        modelBuilder.Entity<Vehicle>().HasMany(f => f.features).WithMany(t => t.vehicles).UsingEntity(j => j.ToTable("VehicleVehicleFeature"));
            
        Vehicle v1 = new() { Id = 1, BrandId = 1, ModelName = "Focus", VinNumber = "VIN001", LicensePlate = "ABC001" };
        
        modelBuilder.Entity<Vehicle>().HasData(v1);

    }
}