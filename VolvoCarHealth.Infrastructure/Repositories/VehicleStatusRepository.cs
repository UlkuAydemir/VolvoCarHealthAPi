using Microsoft.EntityFrameworkCore;
using VolvoCarHealth.Domain.Entities;
using VolvoCarHealth.Infrastructure.Data;

namespace VolvoCarHealth.Infrastructure.Repositories;

public class VehicleStatusRepository : BaseRepository<VehicleStatus, VehicleContext>, IVehicleStatusRepository
{
    public VehicleStatusRepository(VehicleContext context) : base(context)
    {
    }

    public async Task<IEnumerable<VehicleStatus>> GetAllAsync()
    {
        return await _context.VehicleStatuses.ToListAsync();
    }

    public async Task<VehicleStatus> AddAsync(VehicleStatus entity)
    {
        _context.VehicleStatuses.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<VehicleStatus?> GetByIdAsync(int id)
    {
        return await _context.VehicleStatuses.FindAsync(id);
    }

    public async Task<VehicleStatus> UpdateAsync(VehicleStatus updatedEntity)
    {
        var existing = await _context.VehicleStatuses.FindAsync(updatedEntity.Id);
        if (existing == null)
            throw new InvalidOperationException("Entity not found");

        _context.Entry(existing).CurrentValues.SetValues(updatedEntity);
        await _context.SaveChangesAsync();

        return existing;
    }

    public async Task DeleteAsync(VehicleStatus entity)
    {
        _context.VehicleStatuses.Remove(entity);
        await _context.SaveChangesAsync();
    }

}
