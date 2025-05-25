using Xunit;
using Microsoft.EntityFrameworkCore;
using VolvoCarHealth.Domain.Entities;
using VolvoCarHealth.Infrastructure.Data;
using VolvoCarHealth.Infrastructure.Repositories;
using System.Linq;

public class VehicleStatusRepositoryTests
{
    private VehicleContext _context;

    public VehicleStatusRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<VehicleContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _context = new VehicleContext(options);

        // Test için data ekle
        _context.VehicleStatuses.Add(new VehicleStatus
        {
            Id = 1,
            BatteryLevel = 80,
            OilLevel = 70,
            EngineTemperature = 90.5f,
            LastUpdated = DateTime.Now
        });
        _context.SaveChanges();
    }

    [Fact]
    public void GetAll_ReturnsAllVehicleStatuses()
    {
        // Arrange
        var repo = new VehicleStatusRepository(_context);

        // Act
        var result = repo.GetAll();

        // Assert
        Assert.Single(result);
        Assert.Equal(80, result.First().BatteryLevel);
    }
}
