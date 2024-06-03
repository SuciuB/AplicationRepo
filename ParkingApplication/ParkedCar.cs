
namespace ParkingApplication;

public class ParkedCar
{
    public ParkedCar(string userName, string carNumber, DateTime inTime)
    {
        InTime = inTime;
        UserName = userName;
        CarNumber = carNumber;
        ExitTime = null; 
    }
    public ParkedCar(string userName, string carNumber)
    {
        UserName = userName;
        CarNumber = carNumber;
        ExitTime = null; 
        InTime = DateTime.Now;
    }
    public string UserName { get; set; }
    public string CarNumber { get; set; }
    public DateTime InTime { get; set; }
    public DateTime? ExitTime { get; set; }
}