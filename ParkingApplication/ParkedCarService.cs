
using ParkingApplication;

namespace ParkingApplication;

public class ParkedCar : IParkedCarService
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
    public int MaxSlots { get; set; }

    public List<ParkedCar> ListOfParkedCar = new List<ParkedCar> { new ParkedCar(1, "Bogdan",  "abc"), new ParkedCar(2, "Andrei",  "abcde")};
    // public void AddToParking(int id, string userName,string? carNumber = null)
    // {
    //     if(ListOfParkedCar.Count < MaxSlots && carNumber != null)
    //     {
    //             var Car = new ParkedCar(id, userName, carNumber);
    //             ListOfParkedCar.Add(Car);
    //     }
    // }
}