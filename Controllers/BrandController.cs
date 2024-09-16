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
    public Task<List<BrandDTO>> GetBrands()
    {
        return _repo.GetBrands();
    }
}