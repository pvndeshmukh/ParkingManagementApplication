namespace ParkingManagementService
{
    /// <summary>
    /// This abstraction describes the different VehicleSizes and which type of ParkingSlots they can fit in
    /// </summary>
    public interface IVehicleSizeAndParkingSlotSizes
    {
        List<ParkingSlotsSize> ParkingSlotsSizes { get; set; }
        VehicleSize VehicleSize { get; set; }
    }
}