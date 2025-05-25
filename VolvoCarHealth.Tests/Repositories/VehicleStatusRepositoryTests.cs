using Xunit;
using Microsoft.EntityFrameworkCore;
using VolvoCarHealth.Domain.Entities;
using VolvoCarHealth.Infrastructure.Data;
using VolvoCarHealth.Infrastructure.Repositories;
using System.Linq;

public class VehicleStatusRepositoryTests
{
 
    private VehicleContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<VehicleContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Her test için temiz db
            .Options;
        return new VehicleContext(options);
    }

    [Fact]
    public void GetAll_ReturnsAllVehicleStatuses()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repo = new VehicleStatusRepository(context);

        var newStatus = new VehicleStatus { BatteryLevel = 80, OilLevel = 70, EngineTemperature = 90, LastUpdated = DateTime.UtcNow };

        context.VehicleStatuses.Add(newStatus);
        context.SaveChanges();

        // Act
        var result = repo.GetAll();

        // Assert
        Assert.Single(result);
        Assert.Equal(80, result.First().BatteryLevel);
    }

    [Fact]
    public async Task AddAsync_AddsNewVehicleStatus()
    {
        var context = GetInMemoryDbContext();
        var repo = new VehicleStatusRepository(context);

        var newStatus = new VehicleStatus { BatteryLevel = 80, OilLevel = 70, EngineTemperature = 90, LastUpdated = DateTime.UtcNow };

        var result = await repo.AddAsync(newStatus);

        Assert.NotNull(result);
        Assert.True(result.Id > 0);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsVehicleStatus()
    {
        var context = GetInMemoryDbContext();
        var repo = new VehicleStatusRepository(context);

        var status = new VehicleStatus { BatteryLevel = 80, OilLevel = 70, EngineTemperature = 90, LastUpdated = DateTime.UtcNow };
        context.VehicleStatuses.Add(status);
        await context.SaveChangesAsync();

        var result = await repo.GetByIdAsync(status.Id);

        Assert.NotNull(result);
        Assert.Equal(status.Id, result.Id);
    }

    [Fact]
    public async Task UpdateAsync_UpdatesVehicleStatus()
    {
        var context = GetInMemoryDbContext();
        var repo = new VehicleStatusRepository(context);

        var status = new VehicleStatus { BatteryLevel = 50, OilLevel = 40, EngineTemperature = 70, LastUpdated = DateTime.UtcNow };
        context.VehicleStatuses.Add(status);
        await context.SaveChangesAsync();

        status.BatteryLevel = 90;
        var updated = await repo.UpdateAsync(status);

        Assert.Equal(90, updated.BatteryLevel);
    }

    [Fact]
    public async Task DeleteAsync_DeletesVehicleStatus()
    {
        var context = GetInMemoryDbContext();
        var repo = new VehicleStatusRepository(context);

        var status = new VehicleStatus { BatteryLevel = 60, OilLevel = 50, EngineTemperature = 80, LastUpdated = DateTime.UtcNow };
        context.VehicleStatuses.Add(status);
        await context.SaveChangesAsync();

        await repo.DeleteAsync(status);

        var fromDb = await repo.GetByIdAsync(status.Id);
        Assert.Null(fromDb);
    }
}
