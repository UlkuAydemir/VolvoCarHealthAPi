using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using VolvoCarHealth.Api.Controllers;
using VolvoCarHealth.Infrastructure.Repositories;
using VolvoCarHealth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class VehicleStatusControllerTests
{
    [Fact]
    public async Task Create_ReturnsCreatedAtAction()
    {
        var mockRepo = new Mock<IVehicleStatusRepository>();
        var newStatus = new VehicleStatus { Id = 1, BatteryLevel = 80, OilLevel = 70, EngineTemperature = 90, LastUpdated = DateTime.UtcNow };

        mockRepo.Setup(r => r.AddAsync(It.IsAny<VehicleStatus>())).ReturnsAsync(newStatus);

        var controller = new VehicleStatusController(mockRepo.Object);

        var result = await controller.Create(newStatus);

        var createdAtAction = Assert.IsType<CreatedAtActionResult>(result);
        var returnValue = Assert.IsType<VehicleStatus>(createdAtAction.Value);
        Assert.Equal(newStatus.Id, returnValue.Id);
    }

    [Fact]
    public async Task GetById_ReturnsOkObjectResult_WithVehicleStatus()
    {
        var mockRepo = new Mock<IVehicleStatusRepository>();
        var existingStatus = new VehicleStatus { Id = 1, BatteryLevel = 70, OilLevel = 60, EngineTemperature = 85, LastUpdated = DateTime.UtcNow };

        mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingStatus);

        var controller = new VehicleStatusController(mockRepo.Object);

        var result = await controller.GetById(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<VehicleStatus>(okResult.Value);
        Assert.Equal(existingStatus.Id, returnValue.Id);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenStatusDoesNotExist()
    {
        var mockRepo = new Mock<IVehicleStatusRepository>();

        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((VehicleStatus)null);

        var controller = new VehicleStatusController(mockRepo.Object);

        var result = await controller.GetById(999);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Update_ReturnsOkObjectResult_WhenUpdateSuccessful()
    {
        var mockRepo = new Mock<IVehicleStatusRepository>();
        var existingStatus = new VehicleStatus { Id = 1, BatteryLevel = 70, OilLevel = 60, EngineTemperature = 85, LastUpdated = DateTime.UtcNow };

        mockRepo.Setup(r => r.GetByIdAsync(existingStatus.Id)).ReturnsAsync(existingStatus);
        mockRepo.Setup(r => r.UpdateAsync(existingStatus)).ReturnsAsync(existingStatus);

        var controller = new VehicleStatusController(mockRepo.Object);

        var result = await controller.Update(existingStatus.Id, existingStatus);

        var okResult = Assert.IsType<OkObjectResult>(result);  
        var returnedStatus = Assert.IsType<VehicleStatus>(okResult.Value); 
        Assert.Equal(existingStatus.Id, returnedStatus.Id); 
    }


    [Fact]
    public async Task Update_ReturnsBadRequest_WhenIdMismatch()
    {
        var mockRepo = new Mock<IVehicleStatusRepository>();

        var controller = new VehicleStatusController(mockRepo.Object);

        var result = await controller.Update(1, new VehicleStatus { Id = 2 });

        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Id mismatch", badRequestResult.Value);
    }

    [Fact]
    public async Task Update_ReturnsNotFound_WhenEntityDoesNotExist()
    {
        var mockRepo = new Mock<IVehicleStatusRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((VehicleStatus)null);

        var controller = new VehicleStatusController(mockRepo.Object);

        var result = await controller.Update(1, new VehicleStatus { Id = 1 });

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Delete_ReturnsNoContent_WhenDeleteSuccessful()
    {
        var mockRepo = new Mock<IVehicleStatusRepository>();
        var entity = new VehicleStatus { Id = 1 };

        mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(entity);
        mockRepo.Setup(r => r.DeleteAsync(entity)).Returns(Task.CompletedTask);

        var controller = new VehicleStatusController(mockRepo.Object);

        var result = await controller.Delete(1);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Delete_ReturnsNotFound_WhenEntityDoesNotExist()
    {
        var mockRepo = new Mock<IVehicleStatusRepository>();

        // Entity bulunamadığında null dönmeli
        mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((VehicleStatus)null);

        var controller = new VehicleStatusController(mockRepo.Object);

        var result = await controller.Delete(1);

        Assert.IsType<NotFoundResult>(result);
    }
}