namespace ParkingManagementService;

/// <summary>
/// This enum describes the different vehicle types
/// This will be exposed to outer world, because any incoming vehicle will get categorized based on it's type
/// So for any vehicle which is coming into parking, based on it's type system will decide parking number, downstream in system
/// For now it supports five types of vehicle like HatchBack Sedan, CompactSUV, SUV, LargeCars
/// It's very easy to extend and accommodate different types of vehicle in future like bikes, autos and trucks
/// </summary>
public enum VehicleType
{
    HatchBack = 0,
    Sedan = 1,
    CompactSUV = 2,
    SUV = 3,
    LargeCars = 4
}