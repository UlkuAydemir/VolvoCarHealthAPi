using VolvoCarHealth.Domain.Entities;
using VolvoCarHealth.Infrastructure.Data;

namespace VolvoCarHealth.Infrastructure.Repositories;

public class VehicleStatusRepository : IVehicleStatusRepository
{
    private readonly VehicleContext _context;

    public VehicleStatusRepository(VehicleContext context)
    {
        _context = context;
    }

    public IEnumerable<VehicleStatus> GetAll()
    {
        return _context.VehicleStatuses.ToList();
    }
}
