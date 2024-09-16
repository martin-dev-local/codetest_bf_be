using System.ComponentModel.DataAnnotations;

namespace CodetestBF.WebApi.Models;

public class VehicleFeatureDTO
{
    public int Id { get; set; }
    [Required]
    [StringLength(50), MinLength(1)]
    [RegularExpression(@"^[a-zA-ZåäöÅÄÖ\x20]{1,50}$", 
         ErrorMessage = "Characters are not allowed.")]
    public required string Name { get; set; }
}