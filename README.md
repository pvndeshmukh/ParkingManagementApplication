## Problem Statement
Design a small parking management application which can be used for parking lot owners. 
The application will have below mentioned features

1. There will be three different types of parking slots Small, Medium, Large
2. All parking slots are numbered from 1 to 100
3. There are total 50 small, 30 Medium and 20 Large Parking slot
4. People can park three types of cars Hatchback, Sedan/Compact SUV, SUV or Large cars
5. There is a security guard at the entry of the parking who checks the type of vehicle assigns a
parking slot
6. People can then drive to the respective parking slot and park their vehicle
7. Hatchback cars can fit in Small, Medium and Large parking slots, Sedan/Compact SUV can fit
in Medium and Large slots and SUV or Large cars can fit in Large slot only
8. The system should always try and find the best matching slot for the car and then use the
un-utilized ones
9. At any given point in time only one car can enter the parking lot and one car can leave the
parking lot.
10. The system needs to keep a track of available slots and assign the slots accordingly
11. The system should be extendable such that new types of slots can be added to
accommodate two wheelers and trucks also in future

Please design an application to cater these business requirements. It can be any type of application,
a console application or a web application. The application needs to be highly scalable, extendable,
testable and loosely coupled application. Please write unit test cases using any of the test
automation framework like NUnit, XUnit, etc. Please submit your assignment by creating a Git
repository and providing the access to the same.

## ***Consideration***
<br>For points 2 and 3 I have taken Total -> 10 where Small -> 5, Medium -> 3 and Large -> 2
Just for the sake of pictorial view in the console window.
Though these values/configurations are really scalable, Navigate to `ParkingManagementService.ParkingSlotsSize` enum and change your value 
<br> **Total = Small + Medium + Large** <br> Scalability Like `Total = Mini + Small + Medium + Large` or `Total = Mini + Small + Medium + Large + ExtraLarge` is possible
```csharp
public enum ParkingSlotsSize
{
    Total = 10,
    Small = 5,
    Medium = 3,
    Large = 2
}
```
