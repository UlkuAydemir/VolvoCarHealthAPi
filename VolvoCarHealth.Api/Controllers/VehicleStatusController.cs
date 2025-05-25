using Microsoft.AspNetCore.Mvc;
using VolvoCarHealth.Domain.Entities;
using VolvoCarHealth.Infrastructure.Helpers;
using VolvoCarHealth.Infrastructure.Repositories;

namespace VolvoCarHealth.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleStatusController : ControllerBase
{
    private readonly IVehicleStatusRepository _repository;

    public VehicleStatusController(IVehicleStatusRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var statuses = await _repository.GetAllAsync();
            return Ok(statuses);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VehicleStatus newStatus)
    {
        try
        {
            if (newStatus == null)
                return BadRequest("Request body is null");

            var createdStatus = await _repository.AddAsync(newStatus);
            return CreatedAtAction(nameof(GetById), new { id = createdStatus.Id }, createdStatus);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var status = await _repository.GetByIdAsync(id);
            if (status == null)
                return NotFound();

            return Ok(status);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] VehicleStatus updatedStatus)
    {
        try
        {
            if (updatedStatus == null)
                return BadRequest("Request body is null");

            if (id != updatedStatus.Id)
                return BadRequest("Id mismatch");

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            var updated = await _repository.UpdateAsync(updatedStatus);
            return Ok(updated);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repository.DeleteAsync(existing);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{id}/Summary")]
    public async Task<IActionResult> GetSummary(int id)
    {
        var status = await _repository.GetByIdAsync(id);
        if (status == null)
            return NotFound();

        // Extension method 
        var isCritical = status.IsCritical();
        var summary = status.HealthSummary();

        return Ok(new { isCritical, summary });
    }

    [HttpGet("{id}/DaysUntilMaintenance")]
    public async Task<IActionResult> GetDaysUntilMaintenance(int id)
    {
        var status = await _repository.GetByIdAsync(id);
        if (status == null)
            return NotFound();

        int daysLeft = DateTimeHelper.GetDaysUntilNextMaintenance(status.LastMaintenanceDate, status.MaintenanceIntervalDays, DateTime.UtcNow);
        return Ok(new { VehicleStatusId = id, DaysUntilNextMaintenance = daysLeft });
    }
}
