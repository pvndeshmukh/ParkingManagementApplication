namespace ParkingManagementService;

/// <summary>
/// This service describes the all parking slots 
/// It has been set by business rule like which size can have how many slots
/// Example 50 small, 30 Medium and 20 Large Parking slot
/// </summary>
public class ParkingLot
{
    /// <summary>
    /// ParkingSlots is a source of truth for all available or occupied parking slots
    /// This is one to may relation one ParkingLot can have multiple ParkingSlot
    /// </summary>
    public List<ParkingSlot> ParkingSlots { get; set; }

    /// <summary>
    /// Default constructor to initialize parking lot
    /// </summary>
    public ParkingLot()
    {
        ParkingSlots = new List<ParkingSlot>();

        InitializeParkingSlots();
    }

    /// <summary>
    /// Method InitializeParkingSlots() itself is generic in nature
    /// Here we can shuffle the counts of slots for their size
    /// Example for now we have 50 small, 30 Medium and 20 Large
    /// At any given point of time we can shuffle the Site->Count ratio like Large can increase to 30 and small can to 40 and keep medium 30
    /// To achieve any shuffling we just need to change numbers in ParkingSlotsSize enum and that's all
    /// Make sure ParkingSlotsSize.Total match the total of all sizes, you are good to accommodate any numbers 
    /// Ex We can set Total -> 200, Small -> 50, Medium -> 100, Large -> 50 and system will start serving you for 200 parking slots
    /// </summary>
    private void InitializeParkingSlots()
    {
        int smallSlots = (int)ParkingSlotsSize.Small;

        int mediumSlots = smallSlots + (int)ParkingSlotsSize.Medium;

        int largeSlots = smallSlots + mediumSlots + (int)ParkingSlotsSize.Large;

        for (int i = 1; i <= (int)ParkingSlotsSize.Total; i++)
        {
            if (i > 0 && i <= smallSlots)
            {
                ParkingSlots.Add(new ParkingSlot { SlotNumber = i, ParkingSlotsSize = ParkingSlotsSize.Small });
            }

            if (i > smallSlots && i <= mediumSlots)
            {
                ParkingSlots.Add(new ParkingSlot { SlotNumber = i, ParkingSlotsSize = ParkingSlotsSize.Medium });
            }

            if (i > mediumSlots && i <= largeSlots)
            {
                ParkingSlots.Add(new ParkingSlot { SlotNumber = i, ParkingSlotsSize = ParkingSlotsSize.Large });
            }
        }
    }
}

