using CodetestBF.WebApi.Data;
using Microsoft.AspNetCore.Mvc;
using CodetestBF.WebApi.Models;
using Microsoft.CodeAnalysis;

namespace CodetestBF.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleFeatureController : ControllerBase
{
    private readonly ILogger<VehicleController> _logger;

    private readonly IDataRepository _repo;

    public VehicleFeatureController(ILogger<VehicleController> logger, IDataRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    [HttpGet(Name = "VehicleFeatures")]
    public Task<List<VehicleFeatureDTO>> GetVehicleFeatures()
    {
        return _repo.GetVehicleFeatures();
    }
}