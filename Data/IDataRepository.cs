using CodetestBF.WebApi.Models;
namespace CodetestBF.WebApi.Data;


public interface IDataRepository
{
    public Task<VehicleDTO?> GetVehicle(int id);

    public Task<List<VehicleDTO>> GetVehicles();

    public Task<List<BrandDTO>> GetBrands();
    public Task<List<VehicleFeatureDTO>> GetVehicleFeatures();

    public VehicleDTO VehicleToDTO(Vehicle v);
    public BrandDTO BrandToDTO(Brand b);
    public VehicleFeatureDTO VehicleFeatureToDTO(VehicleFeature vf);

    public Task<VehicleDTO?> CreateVehicle(VehicleDTO vehicleDTO);

}