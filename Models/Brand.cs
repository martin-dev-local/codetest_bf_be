using System.ComponentModel.DataAnnotations;

namespace CodetestBF.WebApi.Models;

public class Brand
{
    public int Id { get; set; }

    [Required]
    [StringLength(40)]
    public string? Name { get; set; }
}