using System.ComponentModel.DataAnnotations;

namespace CodetestBF.WebApi.Models;

public class VehicleFeatureDTO
{
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
}