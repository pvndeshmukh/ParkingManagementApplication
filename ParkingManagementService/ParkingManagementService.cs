namespace ParkingManagementService;

/// <summary>
/// This will have a entire blueprint of parking lot
/// </summary>
public class ParkingManagementService
{
    /// <summary>
    /// This will have a entire blueprint of parking lot
    /// </summary>
    public ParkingLot parkingLot { get; set; }

    /// <summary>
    /// Default constructor to initialize parkingLot
    /// </summary>
    public ParkingManagementService()
    {
        parkingLot = new ParkingLot();
    }


    /// <summary>
    /// This method is responsible to give you free parking slot number
    /// If you closely noticed we are not making any business logic/validation here
    /// This method will simple retune a parking slot based on the business rule we have made in VehiclesCategories.GetAllVehiclesCategories() and VehicleSizeAndParkingSlotSizes.GetVehicleParkingSizes()
    /// So this is a abstraction of business rule, You can make any changes in business rules in downstream and this function will continued to return slots accordingly 
    /// </summary>
    public int ParkVehicle(VehicleType vehicleType)
    {
        var vehiclesCategory = VehiclesCategories.GetAllVehiclesCategories()
            .Where(x => x.VehicleType == vehicleType).FirstOrDefault();

        var parkingSlots = VehicleSizeAndParkingSlotSizes.GetVehicleParkingSizes()
            .Where(x => x.VehicleSize == vehiclesCategory?.VehicleSize).FirstOrDefault()?.ParkingSlotsSizes;

        List<ParkingSlot> availableSlots = GetAvailableSlots();

        foreach (var slotSize in parkingSlots!)
        {
            var check = availableSlots.Where(x => x.ParkingSlotsSize == slotSize).FirstOrDefault();
            if (check != null)
            {
                check.IsOccupied = true; // update in parent variable
                return check.SlotNumber;
            }
        }
        return -1; // No available slot for the specified vehicle type
    }


    /// <summary>
    /// This method is responsible to release parking slot from parking lot
    /// There are few conditions maintain 
    /// 1. You can not asked to release parking slot number which is not available in our parking lot
    ///    Like if out parking system have total 100 slots and you asked to release slot 101, System will message you saying invalid slot number
    /// 2. If you to release slot which his already free system will tell you that as well, System will message you saying slot is already free
    /// 3. If you make valid request function will release slot and make it free 
    /// </summary>
    public int LeaveParking(int slotNumber)
    {
        var parkingSlots = parkingLot.ParkingSlots;

        var slot = parkingSlots.FirstOrDefault(s => s.SlotNumber == slotNumber);

        if (slot == null)
        {
            // Invalid slot number
            return 1;
        }
        if (slot != null && slot.IsOccupied == false)
        {
            // Already free
            return 2;
        }
        if (slot != null && slot.IsOccupied == true)
        {
            // Slot released
            slot.IsOccupied = false;
            return 3;
        }
        return 0;
    }

    /// <summary>
    /// This method will return all available parking slots 
    /// </summary>
    public List<ParkingSlot> GetAvailableSlots()
    {
        return parkingLot.ParkingSlots.Where(s => !s.IsOccupied).ToList();
    }
}

