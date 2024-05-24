
namespace ParckingApplication;

public class ParckedCar
{
    public ParckedCar(string userName, string carNumber)
    {
        UserName = userName;
        CarNumber = carNumber;
    }
    public string UserName { get; set; }
    public string CarNumber { get; set; }
}