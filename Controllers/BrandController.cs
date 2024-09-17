using CodetestBF.WebApi.Data;
using Microsoft.AspNetCore.Mvc;
using CodetestBF.WebApi.Models;
using Microsoft.CodeAnalysis;

namespace CodetestBF.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BrandController : ControllerBase
{
    private readonly ILogger<BrandController> _logger;

    private readonly IDataRepository _repo;

    public BrandController(ILogger<BrandController> logger, IDataRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    [HttpGet(Name = "Brands")]
    public async Task<List<BrandDTO>> GetBrands()
    {
        return await _repo.GetBrands();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(200, Type = typeof(BrandDTO))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetBrand(int id)
    {
        BrandDTO? b = await _repo.GetBrand(id);
        if (b == null) {
            return NotFound();
        }
        return Ok(b);
    }
}