using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodetestBF.WebApi.Models;

public class Vehicle
{
    public int Id { get; set; }

    //en-till-en relation gentemot märke
    public required Brand VehicleBrand{ get; set; }

    [ForeignKey("Brand")]
    public int BrandId { get; set; }
    //många-till-många relation gentemot egenskaper
    public List<VehicleFeature> features { get; } = [];

    [Required]
    [StringLength(40)]
    public string? VinNumber { get; set; }

    [Required]
    [StringLength(12)]
    public string? LicensePlate { get; set; }

    [Required]
    [StringLength(30)]
    public string? ModelName { get; set; }
}