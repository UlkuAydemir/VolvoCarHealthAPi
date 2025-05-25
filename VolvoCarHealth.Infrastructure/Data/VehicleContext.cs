using Microsoft.EntityFrameworkCore;
using VolvoCarHealth.Domain.Entities;

namespace VolvoCarHealth.Infrastructure.Data;

public class VehicleContext : DbContext
{
    public VehicleContext(DbContextOptions<VehicleContext> options) : base(options) { }

    public DbSet<VehicleStatus> VehicleStatuses { get; set; }
}
