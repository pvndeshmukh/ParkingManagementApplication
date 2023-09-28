namespace ParkingManagementService
{
    /// <summary>
    /// This abstract blueprint of entire parking lot system
    /// </summary>
    public interface IParkingManagementService
    {
        ParkingLot parkingLot { get; set; }
        List<ParkingSlot> GetAvailableSlots();
        int LeaveParking(int slotNumber);
        int ParkVehicle(VehicleType vehicleType);
    }
}