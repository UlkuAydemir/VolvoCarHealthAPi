namespace VolvoCarHealth.Infrastructure.Helpers
{
    public static class DateTimeHelper
    {
        // Example: Convert UTC to Local time
        public static DateTime ConvertUtcToLocal(DateTime utcDate)
        {
            return utcDate.ToLocalTime();
        }

        // Example: Format date string
        public static string FormatDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        // Returns the number of days remaining until the next maintenance based on last maintenance date and interval
        public static int GetDaysUntilNextMaintenance(DateTime lastMaintenanceDate, int intervalDays, DateTime now)
        {
            var nextMaintenanceDate = lastMaintenanceDate.AddDays(intervalDays);
            var remaining = (nextMaintenanceDate - now).Days;
            return remaining < 0 ? 0 : remaining;
        }
    }
}

