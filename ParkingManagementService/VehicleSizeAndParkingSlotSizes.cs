namespace ParkingManagementService;

/// <summary>
/// This class describes the different VehicleSizes and which type of ParkingSlots they can fit in
/// This is important class which classify the relation of parking slots sizes and the type of vehicle sizes that parking slot can accommodate
/// Example small size vehicle can go in any of the available parking slot 
/// Obviously priority fot small size vehicle will be P1 -> Small, P2 -> Medium P3 -> Large
/// So business rule will be for small car is to look for P1 if full go to P2 if full go to P3 if full say no parking available 
/// Again It's very easy to extend and accommodate different slots sizes and different types of vehicles they can accommodate
/// </summary>
public class VehicleSizeAndParkingSlotSizes
{
    /// <summary>
    /// This describes the sizes of vehicle which can fit in ParkingSlotsSizes
    /// </summary>
    public VehicleSize VehicleSize { get; set; }

    /// <summary>
    /// This describes different parking slot sizes where vehicle can go.    
    /// </summary>
    public List<ParkingSlotsSize> ParkingSlotsSizes { get; set; }

    /// <summary>
    /// GetParkingSlots will give you the business rule for vehicle sizes where they can fit in.    
    /// </summary>
    public static List<VehicleSizeAndParkingSlotSizes> GetVehicleParkingSizes()
    {
        return new List<VehicleSizeAndParkingSlotSizes>
        {
            new VehicleSizeAndParkingSlotSizes
            {
                VehicleSize = VehicleSize.SmallVehicle,
                ParkingSlotsSizes = new List<ParkingSlotsSize>
                {
                    ParkingSlotsSize.Small,
                    ParkingSlotsSize.Medium,
                    ParkingSlotsSize.Large
                },
            },
            new VehicleSizeAndParkingSlotSizes
            {
                VehicleSize = VehicleSize.MediumVehicle,
                ParkingSlotsSizes = new List<ParkingSlotsSize>
                {
                    ParkingSlotsSize.Medium,
                    ParkingSlotsSize.Large
                },
            },
            new VehicleSizeAndParkingSlotSizes
            {
                VehicleSize = VehicleSize.LargeVehicle,
                ParkingSlotsSizes = new List<ParkingSlotsSize>
                {
                    ParkingSlotsSize.Large
                },
            },
        };
    }
}
