using Microsoft.AspNetCore.Mvc;
using VolvoCarHealth.Domain.Entities;
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
    public IActionResult Get()
    {
        var statuses = _repository.GetAll();
        return Ok(statuses);
    }

    // Create
    [HttpPost]
    public async Task<IActionResult> Create(VehicleStatus newStatus)
    {
        var createdStatus = await _repository.AddAsync(newStatus);
        return CreatedAtAction(nameof(GetById), new { id = createdStatus.Id }, createdStatus);
    }

    // Read (Get by Id)
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var status = await _repository.GetByIdAsync(id);
        if (status == null) return NotFound();
        return Ok(status);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, VehicleStatus updatedStatus)
    {
        try
        {
            if (id != updatedStatus.Id)
                return BadRequest("Id mismatch");

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            var updated = await _repository.UpdateAsync(updatedStatus);
            return Ok(updated); // Güncellenmiş veri geri döndürülüyor
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // Delete
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        await _repository.DeleteAsync(existing);
        return NoContent();
    }
}
