using System.ComponentModel.DataAnnotations;

namespace CodetestBF.WebApi.Models;

public class BrandDTO
{
    public int Id { get; set; }
    [Required]
    [StringLength(40), MinLength(1)]
    public required string Name { get; set; }
}