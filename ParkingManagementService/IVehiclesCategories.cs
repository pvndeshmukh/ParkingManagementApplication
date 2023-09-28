namespace ParkingManagementService
{
    /// <summary>
    /// This abstraction describes the different vehicles based on their types and sizes
    /// </summary>
    public interface IVehiclesCategories
    {
        VehicleSize VehicleSize { get; set; }
        VehicleType VehicleType { get; set; }
    }
}