using CodetestBF.WebApi.Data;
using Microsoft.AspNetCore.Mvc;
using CodetestBF.WebApi.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CodetestBF.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private readonly ILogger<VehicleController> _logger;

    private readonly CodetestBFDb _dbContext;

    private readonly IDataRepository _repo;

    public VehicleController(ILogger<VehicleController> logger, CodetestBFDb dbContext, IDataRepository repo)
    {
        _logger = logger;
        _dbContext = dbContext;
        _repo = repo;
    }

    [HttpGet(Name = "Vehicles")]
    public async Task<List<VehicleDTO>> GetVehicles()
    {
        return await _repo.GetVehicles();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(200, Type = typeof(VehicleDTO))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetVehicle(int id)
    {
        VehicleDTO? v = await _repo.GetVehicle(id);
        if (v == null) {
            return NotFound();
        }
        return Ok(v);
    }
    [HttpPost(Name = "CreateVehicle")]
    [ProducesResponseType(201, Type = typeof(VehicleDTO))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateVehicle([FromBody] VehicleDTO vDto)
    {
        if (vDto == null) {
            return BadRequest();
        }
        VehicleDTO? NewVehicle = await _repo.CreateVehicle(vDto);
        if (NewVehicle == null) {
            return BadRequest();
        }
        return CreatedAtAction(nameof(GetVehicle), new { id = NewVehicle.Id}, NewVehicle);
    }
}