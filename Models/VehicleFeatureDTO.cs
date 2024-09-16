using System.ComponentModel.DataAnnotations;

namespace CodetestBF.WebApi.Models;

public class VehicleFeatureDTO
{
    public int Id { get; set; }
    [Required]
    [StringLength(50), MinLength(1)]
    public required string Name { get; set; }
}