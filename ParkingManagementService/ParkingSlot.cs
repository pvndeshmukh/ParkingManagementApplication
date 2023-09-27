namespace ParkingManagementService;

/// <summary>
/// This is a standard ParkingSlot object print
/// </summary>
public class ParkingSlot
{
    /// <summary>
    /// This describes the slot number 
    /// </summary>
    public int SlotNumber { get; set; }

    /// <summary>
    /// This describes the size of parking slot
    /// </summary>
    public ParkingSlotsSize ParkingSlotsSize { get; set; }

    /// <summary>
    /// This describes the present status of slot default set to false = free and true = occupied 
    /// </summary>
    public bool IsOccupied { get; set; }
}