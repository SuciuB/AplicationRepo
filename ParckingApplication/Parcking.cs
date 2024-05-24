
namespace ParckingApplication;

public class Parking
{
    public int MaxSlots = 4;

    public List<ParckedCar> ListOfParckedCar = new List<ParckedCar> { new ParckedCar("Bogdan", "abc"), new ParckedCar("Andrei", "abc")};
    

    public void AddFunction(string userName, string? carNumber = null)
    {
        if(ListOfParckedCar.Count < MaxSlots && carNumber != null)
        {
            var Car = new ParckedCar(userName, carNumber);
            ListOfParckedCar.Add(Car);
        }
    }
}