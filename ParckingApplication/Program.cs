

namespace ParckingApplication;

public static class Program
{
    public static int Result = 4;

    public static void Main()
    {



    }

    public static ParckedCar parckedCar = new ParckedCar("Bogdan", "abc");
    public static ParckedCar parckedCar1 = new ParckedCar("Andrei", "abc");

    public static List<ParckedCar> ListOfParckedCar = new List<ParckedCar> { parckedCar, parckedCar1 };
    

    public static void AddFunction(ParckedCar Car)
    {
        if(ListOfParckedCar.Count < Result)
        {
            ListOfParckedCar.Add(Car);
        }
    }



}
