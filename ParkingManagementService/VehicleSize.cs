namespace ParkingManagementService;

/// <summary>
/// This enum describes the different sizes of vehicle
/// For now it supports three types of vehicle size like SmallVehicle, MediumVehicle, LargeVehicle
/// It's very easy to extend and accommodate different sizes of vehicle in future like MiniVehicle may be for autos and bikes or ExtraLargeVehicle for trucks
/// Also this enum is very important for system to understand which VehicleType falls under which VehicleSizes
/// </summary>
public enum VehicleSize
{
    SmallVehicle,
    MediumVehicle,
    LargeVehicle,
}
