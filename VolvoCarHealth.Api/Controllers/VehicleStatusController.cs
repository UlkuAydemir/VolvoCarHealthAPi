using Microsoft.AspNetCore.Mvc;
using VolvoCarHealth.Domain.Entities;
using VolvoCarHealth.Infrastructure.Repositories;

namespace VolvoCarHealth.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleStatusController : ControllerBase
{
    private readonly IVehicleStatusRepository _repo;

    public VehicleStatusController(IVehicleStatusRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var statuses = _repo.GetAll();
        return Ok(statuses);
    }
}
