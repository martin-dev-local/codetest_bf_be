using CodetestBF.WebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodetestBF.WebApi.Data;

public class DataRepository : IDataRepository
{
    private readonly CodetestBFDb _dbContext;

    public DataRepository(CodetestBFDb dbContext) {
        _dbContext = dbContext;
    }

    public async Task<List<VehicleDTO>> GetVehicles() {
        List<VehicleDTO> vehiclesDto = [];
        List<Vehicle> vehicles = await _dbContext.vehicles.Include(v => v.VehicleBrand).Include(v => v.features).ToListAsync();
        foreach (Vehicle v in vehicles) {
            vehiclesDto.Add(VehicleToDTO(v));
        }
        return vehiclesDto;
    }

    public async Task<List<BrandDTO>> GetBrands() {
        List<BrandDTO> brandsDto = [];
        List<Brand> brands = await _dbContext.brands.ToListAsync();
        foreach (Brand b in brands) {
            brandsDto.Add(BrandToDTO(b));
        }
        return brandsDto;
    }

    public async Task<List<VehicleFeatureDTO>> GetVehicleFeatures() {
        List<VehicleFeatureDTO> vfsDto = [];
        List<VehicleFeature> vfs = await _dbContext.features.ToListAsync();
        foreach (VehicleFeature vf in vfs) {
            vfsDto.Add(VehicleFeatureToDTO(vf));
        }
        return vfsDto;
    }

    public VehicleDTO VehicleToDTO(Vehicle v) {
        VehicleDTO vDto = new() {Id = v.Id, ModelName = v.ModelName, VinNumber = v.VinNumber, LicensePlate = v.LicensePlate};
        vDto.BrandId = v.BrandId;
        if (v.VehicleBrand != null) {
            vDto.Brand = BrandToDTO(v.VehicleBrand);
        }
        foreach (VehicleFeature vf in v.features) {
            vDto.Features.Add(VehicleFeatureToDTO(vf));
            vDto.AssignedFeatures.Add(vf.Id);
        }
        return vDto;
    }

    public BrandDTO BrandToDTO(Brand b) {
        BrandDTO bDto = new() {Id = b.Id, Name = b.Name };
        return bDto;
    }

    public VehicleFeatureDTO VehicleFeatureToDTO(VehicleFeature vf) {
        VehicleFeatureDTO vfDto = new() { Id = vf.Id, Name = vf.Name };
        return vfDto;
    }

    public async Task<VehicleDTO?> CreateVehicle(VehicleDTO vehicleDto)
    {
        
        Vehicle v = new() {BrandId = vehicleDto.BrandId, LicensePlate = vehicleDto.LicensePlate, 
        ModelName = vehicleDto.ModelName, VinNumber = vehicleDto.VinNumber};
        List<VehicleFeature> dbFeatures = await _dbContext.features.Where(f => vehicleDto.AssignedFeatures.Contains(f.Id)).ToListAsync();
        Brand? b = await _dbContext.brands.FindAsync(v.BrandId);
        if (b == null) {
            return null;
        }
        if (vehicleDto.AssignedFeatures.Count != dbFeatures.Count) {
            return null;
        }
        v.VehicleBrand = b;
        v.features.AddRange(dbFeatures);
        EntityEntry<Vehicle> addedVehicle = await _dbContext.vehicles.AddAsync(v);
        int affected = await _dbContext.SaveChangesAsync();
        if (affected == 0) {
            return null;
        }
        return VehicleToDTO(v);
    }

    public async Task<VehicleDTO?> GetVehicle(int id)
    {
        Vehicle? v = await _dbContext.vehicles.Include(v => v.VehicleBrand).Include(v => v.features).FirstOrDefaultAsync(v => v.Id == id);
        if (v == null) {
            return null;
        }
        return VehicleToDTO(v);
    }
}