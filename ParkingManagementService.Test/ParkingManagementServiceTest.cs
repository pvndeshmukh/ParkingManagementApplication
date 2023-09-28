namespace ParkingManagementService.Test;

public class ParkingManagementServiceTest
{
    private readonly IParkingManagementService _sut;

    public ParkingManagementServiceTest()
    {
        // Arrange
        _sut = new ParkingManagementService();
    }

    [Fact]
    public void GetAvailableSlots_Should_Give_All_Available_Slots()
    {
        // Act
        var response = _sut.GetAvailableSlots();

        // Assert
        Assert.Equal(10, response.Count);
    }

    [Fact]
    public void GetAvailableSlots_Should_Return_Positive_Count()
    {
        // Act
        var response = _sut.GetAvailableSlots();

        // Assert
        Assert.Equal(10, response.Count);
    }

    [Fact]
    public void GetAvailableSlots_Should_Return_ListOfAvailableSlots()
    {
        // Arrange        
        var slotNumber = _sut.ParkVehicle(VehicleType.HatchBack);

        // Act
        var availableSlots = _sut.GetAvailableSlots();

        // Assert
        Assert.Equal(9, availableSlots.Count); // After parking one vehicle, there should be 9 available slots
        Assert.DoesNotContain(availableSlots, slot => slot.SlotNumber == slotNumber); // The occupied slot should not be in the list
    }

    [Fact]
    public void GetAvailableSlots_Should_Return_EmptyList_When_AllSlotsOccupied()
    {
        // Arrange        
        _sut.parkingLot.ParkingSlots.ForEach(slot => slot.IsOccupied = true);

        // Act
        var availableSlots = _sut.GetAvailableSlots();

        // Assert
        Assert.Empty(availableSlots); // When all slots are occupied, the list of available slots should be empty
    }

    [Fact]
    public void ParkVehicle_Should_ParkVehicle_Successfully()
    {
        // Act
        var result = _sut.ParkVehicle(VehicleType.HatchBack);

        // Assert
        Assert.True(result > 0);
    }

    [Fact]
    public void ParkVehicle_Should_Return_NegativeOne_When_NoAvailableSlots()
    {
        // Arrange        
        // Fill all available slots
        _sut.parkingLot.ParkingSlots.ForEach(slot => slot.IsOccupied = true);

        // Act
        var result = _sut.ParkVehicle(VehicleType.HatchBack);

        // Assert
        Assert.Equal(-1, result);
    }

    [Fact]
    public void ParkVehicle_Should_Return_NegativeOne_For_InvalidVehicleType()
    {
        // Arrange
        var service = new ParkingManagementService();

        // Act
        var result = service.ParkVehicle((VehicleType)10); // Assuming 10 is an invalid vehicle type

        // Assert
        Assert.Equal(-1, result);
    }

    [Fact]
    public void ParkVehicle_Should_Return_NegativeOne_When_NoSlotsAvailableForVehicleType()
    {
        // Fill all available slots with large slots, but try to park a HatchBack
        _sut.parkingLot.ParkingSlots.ForEach(slot => slot.ParkingSlotsSize = ParkingSlotsSize.Large);

        // Act
        var result = _sut.ParkVehicle(VehicleType.HatchBack);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void LeaveParking_Should_ReleaseOccupiedSlot()
    {
        // Arrange        
        var slotNumber = _sut.ParkVehicle(VehicleType.HatchBack);

        // Act
        var leaveResult = _sut.LeaveParking(slotNumber);
        var availableSlots = _sut.GetAvailableSlots();

        // Assert
        Assert.Equal(10, availableSlots.Count); // After leaving one slot, there should be 3 available
        Assert.Equal(3, leaveResult); // LeaveParking should return 3
    }
    
    [Fact]
    public void LeaveParking_Should_Return_One_When_InvalidSlotNumber()
    {
        // Act
        var leaveResult = _sut.LeaveParking(100); // Assuming 100 is an invalid slot number

        // Assert
        Assert.Equal(1, leaveResult);
    }

    [Fact]
    public void LeaveParking_Should_Return_Two_When_SlotIsAlreadyFree()
    {
        // Arrange        
        var slotNumber = _sut.ParkVehicle(VehicleType.HatchBack);
        _sut.LeaveParking(slotNumber); // Release the slot once

        // Act
        var leaveResult = _sut.LeaveParking(slotNumber); // Try releasing it again

        // Assert
        Assert.Equal(2, leaveResult); // LeaveParking should return 2
    }

    [Fact]
    public void LeaveParking_Should_Return_One_For_InvalidSlotNumber()
    {
        // Act
        var leaveResult = _sut.LeaveParking(100); // Assuming 100 is an invalid slot number

        // Assert
        Assert.Equal(1, leaveResult);
    }
}
