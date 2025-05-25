using VolvoCarHealth.Domain.Entities;

namespace VolvoCarHealth.Infrastructure.Repositories;

public interface IVehicleStatusRepository
{
    IEnumerable<VehicleStatus> GetAll();
}
