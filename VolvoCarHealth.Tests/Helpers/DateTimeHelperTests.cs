using VolvoCarHealth.Infrastructure.Helpers;

namespace VolvoCarHealth.Tests.Helpers
{
    public class DateTimeHelperTests
    {
        [Fact]
        public void ConvertUtcToLocal_ShouldReturnLocalTime()
        {
            DateTime utcNow = DateTime.UtcNow;
            var localTime = DateTimeHelper.ConvertUtcToLocal(utcNow);

            Assert.Equal(utcNow.Kind, DateTimeKind.Utc);
            Assert.Equal(localTime.Kind, DateTimeKind.Local);
        }

        [Fact]
        public void FormatDate_ReturnsCorrectStringFormat()
        {
            // Arrange
            DateTime testDate = new DateTime(2025, 5, 25, 14, 30, 45); // 25 May 2025, 14:30:45

            // Act
            string formattedDate = DateTimeHelper.FormatDate(testDate);

            // Assert
            Assert.Equal("2025-05-25 14:30:45", formattedDate);
        }

        [Fact]
        public void GetDaysUntilNextMaintenance_ReturnsCorrectDays_WhenFutureDate()
        {
            // Arrange
            var fixedNow = DateTime.UtcNow;
            var lastMaintenanceDate = fixedNow.AddDays(-10);
            int intervalDays = 30;

            // Act
            var daysLeft = DateTimeHelper.GetDaysUntilNextMaintenance(lastMaintenanceDate, intervalDays, fixedNow);

            // Assert
            Assert.Equal(20, daysLeft);
        }


        [Fact]
        public void GetDaysUntilNextMaintenance_ReturnsZero_WhenMaintenanceOverdue()
        {
            // Arrange
            var fixedNow = DateTime.UtcNow;
            var lastMaintenanceDate = DateTime.UtcNow.AddDays(-40);
            int intervalDays = 30;

            // Act
            var daysLeft = DateTimeHelper.GetDaysUntilNextMaintenance(lastMaintenanceDate, intervalDays, fixedNow);

            // Assert
            Assert.Equal(0, daysLeft);
        }
    }
}
