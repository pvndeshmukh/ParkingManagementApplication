namespace ParkingManagementService.Test;

public class VehicleSizeAndParkingSlotSizesTests
{
    private readonly List<VehicleSizeAndParkingSlotSizes> _sut;

    public VehicleSizeAndParkingSlotSizesTests()
    {
        // Act
        _sut = VehicleSizeAndParkingSlotSizes.GetVehicleParkingSizes();
    }

    [Fact]
    public void GetVehicleParkingSizes_Should_Return_ValidData()
    {
        // Assert
        Assert.NotNull(_sut);
        Assert.NotEmpty(_sut);
        Assert.All(_sut, item =>
        {
            Assert.NotNull(item.VehicleSize);
            Assert.NotEmpty(item.ParkingSlotsSizes);
            Assert.All(item.ParkingSlotsSizes, slotSize => Assert.True(Enum.IsDefined(typeof(ParkingSlotsSize), slotSize)));
        });
    }

    [Fact]
    public void GetVehicleParkingSizes_Should_Contain_Small_VehicleSize()
    {
        // Assert
        Assert.Contains(_sut, item => item.VehicleSize == VehicleSize.SmallVehicle);
    }

    [Fact]
    public void GetVehicleParkingSizes_Should_Contain_Medium_VehicleSize()
    {
        // Assert
        Assert.Contains(_sut, item => item.VehicleSize == VehicleSize.MediumVehicle);
    }

    [Fact]
    public void GetVehicleParkingSizes_Should_Contain_Large_VehicleSize()
    {
        // Assert
        Assert.Contains(_sut, item => item.VehicleSize == VehicleSize.LargeVehicle);
    }

    [Fact]
    public void GetVehicleParkingSizes_Should_Not_Contain_Invalid_VehicleSizes()
    {
        // Arrange
        var invalidVehicleSizes = new[] { (VehicleSize)100, (VehicleSize)101 };

        // Act
        var parkingSizes = VehicleSizeAndParkingSlotSizes.GetVehicleParkingSizes();

        // Assert
        Assert.DoesNotContain(parkingSizes, item => invalidVehicleSizes.Contains(item.VehicleSize));
    }

    [Fact]
    public void GetVehicleParkingSizes_Should_Contain_Valid_ParkingSlotSizes()
    {
        // Act
        var parkingSizes = VehicleSizeAndParkingSlotSizes.GetVehicleParkingSizes();

        // Assert
        Assert.All(parkingSizes, item =>
        {
            Assert.NotNull(item.ParkingSlotsSizes);
            Assert.NotEmpty(item.ParkingSlotsSizes);
            Assert.All(item.ParkingSlotsSizes, slotSize => Assert.True(Enum.IsDefined(typeof(ParkingSlotsSize), slotSize)));
        });
    }
}
