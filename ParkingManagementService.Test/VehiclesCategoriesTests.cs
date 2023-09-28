namespace ParkingManagementService.Test;

public class VehiclesCategoriesTests
{
    private readonly List<VehiclesCategories> _sut;

    public  VehiclesCategoriesTests()
    {
        // Arrange
        _sut = VehiclesCategories.GetAllVehiclesCategories();
    }

    [Fact]
    public void GetAllVehiclesCategories_Should_Return_ValidData()
    {
        // Assert
        Assert.NotNull(_sut);
        Assert.NotEmpty(_sut);
        Assert.All(_sut, item =>
        {
            Assert.NotNull(item.VehicleType);
            Assert.NotNull(item.VehicleSize);
            Assert.True(Enum.IsDefined(typeof(VehicleType), item.VehicleType));
            Assert.True(Enum.IsDefined(typeof(VehicleSize), item.VehicleSize));
        });
    }

    [Fact]
    public void GetAllVehiclesCategories_Should_Contain_Valid_VehicleTypes()
    {
        // Assert
        Assert.All(_sut, item =>
        {
            Assert.True(Enum.IsDefined(typeof(VehicleType), item.VehicleType));
        });
    }

    [Fact]
    public void GetAllVehiclesCategories_Should_Contain_Valid_VehicleSizes()
    {
        // Assert
        Assert.All(_sut, item =>
        {
            Assert.True(Enum.IsDefined(typeof(VehicleSize), item.VehicleSize));
        });
    }

    [Fact]
    public void GetAllVehiclesCategories_Should_Not_Contain_Invalid_VehicleTypes()
    {
        // Arrange
        var invalidVehicleTypes = new[] { (VehicleType)10, (VehicleType)11 };

        // Act
        var vehicleCategories = VehiclesCategories.GetAllVehiclesCategories();

        // Assert
        Assert.DoesNotContain(vehicleCategories, item => invalidVehicleTypes.Contains(item.VehicleType));
    }

    [Fact]
    public void GetAllVehiclesCategories_Should_Not_Contain_Invalid_VehicleSizes()
    {
        // Arrange
        var invalidVehicleSizes = new[] { (VehicleSize)10, (VehicleSize)11 };

        // Act
        var vehicleCategories = VehiclesCategories.GetAllVehiclesCategories();

        // Assert
        Assert.DoesNotContain(vehicleCategories, item => invalidVehicleSizes.Contains(item.VehicleSize));
    }
}
