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

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(200, Type = typeof(VehicleFeatureDTO))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetBrand(int id)
    {
        VehicleFeatureDTO? vf = await _repo.GetVehicleFeature(id);
        if (vf == null) {
            return NotFound();
        }
        return Ok(vf);
    }
}