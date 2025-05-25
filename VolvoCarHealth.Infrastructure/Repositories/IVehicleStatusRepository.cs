using VolvoCarHealth.Domain.Entities;

namespace VolvoCarHealth.Infrastructure.Repositories;

public interface IVehicleStatusRepository
{
    IEnumerable<VehicleStatus> GetAll();

    Task<VehicleStatus> AddAsync(VehicleStatus entity);
    Task<VehicleStatus?> GetByIdAsync(int id);
    Task<VehicleStatus> UpdateAsync(VehicleStatus entity);
    Task DeleteAsync(VehicleStatus entity);
}
