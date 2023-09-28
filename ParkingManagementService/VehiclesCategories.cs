namespace ParkingManagementService;

/// <summary>
/// This class describes the different vehicles based on their types and sizes
/// Again this is very important class classify any vehicle based on it's type
/// For now we have five different types of vehicle so we have group them with specific size
/// Again It's very easy to extend and accommodate different sizes and different types of vehicle in future like Auto/Bike -> MiniVehicle OR Trucks -> ExtraLargeVehicle
/// </summary>
public class VehiclesCategories : IVehiclesCategories
{
    /// <summary>
    /// This describes type of vehicle.    
    /// </summary>
    public VehicleType VehicleType { get; set; }

    /// <summary>
    /// This describes size of vehicle.    
    /// </summary>
    public VehicleSize VehicleSize { get; set; }

    /// <summary>
    /// GetAllVehiclesCategories will give you all the business rule for the type and size of vehicle.    
    /// </summary>
    public static List<VehiclesCategories> GetAllVehiclesCategories()
    {
        return new List<VehiclesCategories>
        {
            new VehiclesCategories
            {
                VehicleType = VehicleType.HatchBack,
                VehicleSize = VehicleSize.SmallVehicle
            },
            new VehiclesCategories
            {
                VehicleType = VehicleType.Sedan,
                VehicleSize = VehicleSize.MediumVehicle
            },
            new VehiclesCategories
            {
                VehicleType = VehicleType.CompactSUV,
                VehicleSize = VehicleSize.MediumVehicle
            },
            new VehiclesCategories
            {
                VehicleType = VehicleType.SUV,
                VehicleSize = VehicleSize.LargeVehicle
            },
            new VehiclesCategories
            {
                VehicleType = VehicleType.LargeCars,
                VehicleSize = VehicleSize.LargeVehicle
            },
        };
    }
}