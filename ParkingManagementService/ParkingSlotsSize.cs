namespace ParkingManagementService;

/// <summary>
/// This enum describes the parking slots sizes 
/// For now it supports three types of slots sizes like Small, Medium, Large
/// It's very easy to extend and accommodate different sizes of parking slots like bikes and trucks in future
/// </summary>
public enum ParkingSlotsSize
{
    Total = 10,
    Small = 5,
    Medium = 3,
    Large = 2
}
