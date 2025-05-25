using VolvoCarHealth.Domain.Entities;

public static class VehicleStatusHelper
{
    public static bool IsCritical(this VehicleStatus status)
    {
        return status.BatteryLevel < 20 || status.OilLevel < 25 || status.EngineTemperature > 120;
    }

    public static string HealthSummary(this VehicleStatus status)
    {
        return $"Battery: {status.BatteryLevel}%, Oil: {status.OilLevel}%, Temp: {status.EngineTemperature}°C";
    }
}
