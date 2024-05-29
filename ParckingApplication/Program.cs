

namespace ParckingApplication;

public static class Program
{
    

    public static void Main()
    {
        var parkingLot = new Parking();
        
        // Car exits the parking lot
        parkingLot.ExitFunction("abc", DateTime.Now);
        parkingLot.ExitFunction("abcd", DateTime.Now.AddHours(3)); // John Doe is still parked
        
        // Calculating amounts for parked cars
        parkingLot.CalculateAmount("abcd");
    }

    



}
