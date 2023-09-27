using ParkingManagementService;

namespace ParkingManagementApplication;

public class ParkingManagementServiceConsoleCallingClient
{
    public static void CallMe()
    {
        ParkingManagementService.ParkingManagementService pms = new();

        var availableSlots = pms.GetAvailableSlots();
        Console.WriteLine("Parking Lot Flore Map");
        foreach (var slot in availableSlots)
        {
            Console.WriteLine($"Slot {slot.SlotNumber} - {slot.ParkingSlotsSize}");
        }

        while (true)
        {
            Console.WriteLine();
            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("1. Park Vehicle");
            //Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("2. Leave Parking");
            //Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("3. Get Available Slots");
            //Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("4. Exit");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter your choice: ");
            
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Select vehicle type");
                    Console.WriteLine("0 -> Hatchback");
                    Console.WriteLine("1 -> Sedan");
                    Console.WriteLine("2 -> CompactSUV");
                    Console.WriteLine("3 -> SUV");
                    Console.WriteLine("4 -> LargeCars");
                    Console.Write("Enter your choice: ");
                    if (Enum.TryParse(Console.ReadLine(), out VehicleType vehicleType) && Enum.IsDefined(typeof(VehicleType), vehicleType))
                    {
                        int slotNumber = pms.ParkVehicle(vehicleType);
                        if (slotNumber != -1)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Parked in Slot {slotNumber}");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("No available slot for the specified vehicle type.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid vehicle type, Please try again.");
                    }
                    break;
                case 2:
                    Console.Write("Enter slot number to leave: ");
                    if (int.TryParse(Console.ReadLine(), out int leaveSlot))
                    {
                        int response = pms.LeaveParking(leaveSlot);
                        switch (response)
                        {
                            case 1:
                                Console.WriteLine("Invalid slot number. Please try again.");
                                break;

                            case 2:
                                Console.WriteLine($"Slot {leaveSlot} is already free.");
                                break;

                            case 3:
                                Console.WriteLine($"Slot {leaveSlot} has been vacated.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid slot number. Please try again.");
                    }
                    break;
                case 3:
                    var currentAvailableSlots = pms.GetAvailableSlots();
                    Console.WriteLine();
                    Console.WriteLine("Available Slots:");
                    foreach (var slot in currentAvailableSlots)
                    {
                        Console.WriteLine($"Slot {slot.SlotNumber} - {slot.ParkingSlotsSize}");
                    }
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}