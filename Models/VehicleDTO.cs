using System.ComponentModel.DataAnnotations;

namespace CodetestBF.WebApi.Models;
public class VehicleDTO
{
    public int Id { get; set; }
    public int BrandId { get; set; }

    public BrandDTO? Brand { get; set; }

    [Required]
    public required string ModelName { get; set; }
    [Required]
    public required string VinNumber { get;set; }
    [Required]
    public required string LicensePlate { get; set; }
    public List<int> AssignedFeatures { get; set; } = [];
    public List<VehicleFeatureDTO> Features { get; set; } = [];
}