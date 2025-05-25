using VolvoCarHealth.Domain.Entities;

namespace VolvoCarHealth.Tests.Helpers
{
    public class VehicleStatusHelperTests
    {
        [Theory]
        [InlineData(10, 30, 100, true)]  // Battery below 20% -> critical
        [InlineData(25, 10, 100, true)]  // Oil below 25% -> critical
        [InlineData(30, 50, 130, true)]  // Temperature above 120°C -> critical
        [InlineData(50, 50, 100, false)] // All values normal -> not critical
        public void IsCritical_ReturnsExpectedResult(int battery, int oil, int temp, bool expected)
        {
            // Arrange: create a VehicleStatus with specified values
            var status = new VehicleStatus
            {
                BatteryLevel = battery,
                OilLevel = oil,
                EngineTemperature = temp
            };

            // Act: check if the status is critical
            var result = status.IsCritical();

            // Assert: verify the returned value matches expectation
            Assert.Equal(expected, result);
        }

        [Fact]
        public void HealthSummary_ReturnsCorrectString()
        {
            // Arrange: create a VehicleStatus with fixed values
            var status = new VehicleStatus
            {
                BatteryLevel = 80,
                OilLevel = 70,
                EngineTemperature = 90
            };

            // Expected summary string output
            var expected = "Battery: 80%, Oil: 70%, Temp: 90°C";

            // Act: get the health summary string
            var summary = status.HealthSummary();

            // Assert: check if the returned string matches the expected one
            Assert.Equal(expected, summary);
        }
    }
}
