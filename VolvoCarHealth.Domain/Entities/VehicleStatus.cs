namespace VolvoCarHealth.Domain.Entities;

public class VehicleStatus
{
    public int Id { get; set; }
    public int BatteryLevel { get; set; }
    public int OilLevel { get; set; }
    public float EngineTemperature { get; set; }
    public DateTime LastUpdated { get; set; }
    public DateTime LastMaintenanceDate { get; set; }
    public int MaintenanceIntervalDays { get; set; }
}
