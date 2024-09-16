using CodetestBF.WebApi.Models;
namespace CodetestBF.WebApi.Data;


public interface IDataRepository
{
    public Task<VehicleDTO?> GetVehicle(int id);

    public Task<List<VehicleDTO>> GetVehicleByVinNumber(string VinNumber);

    public Task<List<VehicleDTO>> GetVehicleByLicensePlate(string LicensePlate);
    public Task<List<VehicleDTO>> GetVehicleByModelName(string ModelName);

    public Task<List<VehicleDTO>> GetVehicles();

    public Task<List<BrandDTO>> GetBrands();
    public Task<List<VehicleFeatureDTO>> GetVehicleFeatures();

    public VehicleDTO VehicleToDTO(Vehicle v);
    public BrandDTO BrandToDTO(Brand b);
    public VehicleFeatureDTO VehicleFeatureToDTO(VehicleFeature vf);

    public Task<VehicleDTO?> CreateVehicle(VehicleDTO vehicleDTO);

    public Task<VehicleDTO?> UpdateVehicle(VehicleDTO vehicleDTO);


}