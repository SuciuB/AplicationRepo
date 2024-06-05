
namespace ParkingApplication;

public class ParkedCar
{
    public ParkedCar(int id, string userName, string carNumber, DateTime inTime)
    {
        Id = id;
        InTime = inTime;
        UserName = userName;
        CarNumber = carNumber;
        ExitTime = null; 
    }
    public ParkedCar(int id,string userName, string carNumber)
    {
        Id = id;
        UserName = userName;
        CarNumber = carNumber;
        ExitTime = null; 
        InTime = DateTime.Now;
    }
    public string UserName { get; set; }
    public string CarNumber { get; set; }
    public DateTime InTime { get; set; }
    public DateTime? ExitTime { get; set; }
    public int Id { get; set; }
}