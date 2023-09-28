namespace ParkingManagementService.Test;

public class EnumTests
{
    [Fact]
    public void Enum_ShouldHaveExpectedValues_VehicleType()
    {
        Assert.Equal(0, (int)VehicleType.HatchBack);
        Assert.Equal(1, (int)VehicleType.Sedan);
        Assert.Equal(2, (int)VehicleType.CompactSUV);
        Assert.Equal(3, (int)VehicleType.SUV);
        Assert.Equal(4, (int)VehicleType.LargeCars);
    }

    [Fact]
    public void Enum_ShouldHaveExpectedValues_VehicleSize()
    {
        Assert.Equal(0, (int)VehicleSize.SmallVehicle);
        Assert.Equal(1, (int)VehicleSize.MediumVehicle);
        Assert.Equal(2, (int)VehicleSize.LargeVehicle);
    }

    [Fact]
    public void Enum_ShouldHaveExpectedValues_ParkingSlotsSize()
    {
        Assert.Equal(10, (int)ParkingSlotsSize.Total);
        Assert.Equal(5, (int)ParkingSlotsSize.Small);
        Assert.Equal(3, (int)ParkingSlotsSize.Medium);
        Assert.Equal(2, (int)ParkingSlotsSize.Large);
    }

    [Theory]
    [InlineData(VehicleType.HatchBack, 0)]
    [InlineData(VehicleType.Sedan, 1)]
    [InlineData(VehicleType.CompactSUV, 2)]
    [InlineData(VehicleType.SUV, 3)]
    [InlineData(VehicleType.LargeCars, 4)]
    public void VehicleType_ShouldHaveExpectedValues(VehicleType vehicleType, int expectedValue)
    {
        Assert.Equal(expectedValue, (int)vehicleType);
    }

    [Theory]
    [InlineData(VehicleSize.SmallVehicle, 0)]
    [InlineData(VehicleSize.MediumVehicle, 1)]
    [InlineData(VehicleSize.LargeVehicle, 2)]
    public void VehicleSize_ShouldHaveExpectedValues(VehicleSize vehicleSize, int expectedValue)
    {
        Assert.Equal(expectedValue, (int)vehicleSize);
    }

    [Theory]
    [InlineData(ParkingSlotsSize.Total, 10)]
    [InlineData(ParkingSlotsSize.Small, 5)]
    [InlineData(ParkingSlotsSize.Medium, 3)]
    [InlineData(ParkingSlotsSize.Large, 2)]
    public void ParkingSlotsSize_ShouldHaveExpectedValues(ParkingSlotsSize slotSize, int expectedValue)
    {
        Assert.Equal(expectedValue, (int)slotSize);
    }

    [Fact]
    public void VehicleType_ShouldHaveUniqueValues()
    {
        var values = Enum.GetValues(typeof(VehicleType));
        var distinctValues = new HashSet<int>();

        foreach (var value in values)
        {
            var intValue = (int)value;
            Assert.DoesNotContain(intValue, distinctValues);
            distinctValues.Add(intValue);
        }
    }
}
