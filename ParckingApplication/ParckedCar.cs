
namespace ParckingApplication;

public class ParckedCar
{
    public ParckedCar(string userName, string carNumber, DateTime inTime)
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