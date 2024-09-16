using System.ComponentModel.DataAnnotations;

namespace CodetestBF.WebApi.Models;
public class VehicleDTO
{
    public int Id { get; set; }
    public int BrandId { get; set; }

    public BrandDTO? Brand { get; set; }

    [Required]
    [StringLength(30), MinLength(1)]
    [RegularExpression(@"^[a-zA-Z0-9åäöÅÄÖ\x20]{1,30}$", 
         ErrorMessage = "Characters are not allowed.")]
    public required string ModelName { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9åäöÅÄÖ\x20]{1,40}$", 
         ErrorMessage = "Characters are not allowed.")]
    [StringLength(40), MinLength(1)]
    public required string VinNumber { get;set; }
    [Required]
    [StringLength(12), MinLength(1)]
    [RegularExpression(@"^[a-zA-Z0-9\x20]{1,12}$", 
         ErrorMessage = "Characters are not allowed.")]
    public required string LicensePlate { get; set; }
    public List<int> AssignedFeatures { get; set; } = [];
    public List<VehicleFeatureDTO> Features { get; set; } = [];
}