using System.ComponentModel.DataAnnotations;

namespace CodetestBF.WebApi.Models;

public class BrandDTO
{
    public int Id { get; set; }
    [Required]
    [StringLength(40), MinLength(1)]
    [RegularExpression(@"^[a-zA-ZåäöÅÄÖ\x20]{1,40}$", 
         ErrorMessage = "Characters are not allowed.")]
    public required string Name { get; set; }
}