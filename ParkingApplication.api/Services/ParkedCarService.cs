
using ParkingApplication.Api.Interfaces;

namespace ParkingApplication.Services;

public class ParkedCar : IParkedCarService
{
    public ParkedCar(int id, string carNumber, DateTime inTime)
    {
        Id = id;
        InTime = inTime;
        CarNumber = carNumber;
        ExitTime = null; 
    }
    public ParkedCar(int id, string carNumber, int userId)
    {
        UserId = userId;
        Id = id;
        CarNumber = carNumber;
        ExitTime = null; 
        InTime = DateTime.Now;
    }
    public string CarNumber { get; set; }
    public DateTime InTime { get; set; }
    public DateTime? ExitTime { get; set; }
    public int UserId { get; set; }
    public int Id { get; set; }
    public int MaxSlots { get; set; }
}