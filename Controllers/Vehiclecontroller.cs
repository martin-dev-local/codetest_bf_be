using CodetestBF.WebApi.Data;
using Microsoft.AspNetCore.Mvc;
using CodetestBF.WebApi.Models;

namespace CodetestBF.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private readonly ILogger<VehicleController> _logger;

    private readonly CodetestBFDb _dbContext;

    public VehicleController(ILogger<VehicleController> logger, CodetestBFDb dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "Brands")]
    public IEnumerable<Brand> Get()
    {
        return _dbContext.brands.ToList();
    }
}