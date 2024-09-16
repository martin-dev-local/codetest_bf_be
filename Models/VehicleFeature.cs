using System.ComponentModel.DataAnnotations;

namespace CodetestBF.WebApi.Models;

public class VehicleFeature
{
     public int Id { get; set; }

    //omvända sidan av många-till-många mot fordon
    public List<Vehicle> vehicles { get; } = [];

    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
}