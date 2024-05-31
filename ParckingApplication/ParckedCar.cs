
namespace ParckingApplication;

public class ParckedCar
{
    public ParckedCar(string userName, DateTime inTime, string carNumber)
    {
        InTime = inTime;
        UserName = userName;
        CarNumber = carNumber;
        ExitTime = null; 
    }
    public string UserName { get; set; }
    public string CarNumber { get; set; }
    public DateTime InTime { get; set; }
    public DateTime? ExitTime { get; set; }
}