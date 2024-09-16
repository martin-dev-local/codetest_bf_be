using System.ComponentModel.DataAnnotations;

namespace CodetestBF.WebApi.Models;
public class VehicleDTO
{
    public int Id { get; set; }
    public int BrandId { get; set; }

    public BrandDTO? Brand { get; set; }

    [Required]
    [StringLength(30), MinLength(1)]
    public required string ModelName { get; set; }
    [Required]
    [StringLength(40), MinLength(1)]
    public required string VinNumber { get;set; }
    [Required]
    [StringLength(12), MinLength(1)]
    public required string LicensePlate { get; set; }
    public List<int> AssignedFeatures { get; set; } = [];
    public List<VehicleFeatureDTO> Features { get; set; } = [];
}