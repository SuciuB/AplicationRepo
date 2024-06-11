using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace ParkingApplication;

using ParkingApplication;

public class ParkingService : IParkingService
{      

    public int MaxSlots { get; set; }

    public ParkingService(int maxSlots)
    {
        MaxSlots = maxSlots;
    }

    public List<ParkingModel> ListOfParkedCar = new List<ParkingModel> { new ParkingModel(1, "Bogdan", "Suciu",  "abc"), new ParkingModel(2, "Andrei", "Suciu",  "abcde")};

    public void AddToParking(int id, string firstName, string lastName, string carNumber)
    {
        if(ListOfParkedCar.Count < MaxSlots && carNumber != null)
        {
                var Car = new ParkingModel(id, firstName, lastName, carNumber);
                ListOfParkedCar.Add(Car);
        }
    }


    public bool ExitParking(string carNumber)
    {
        var parkedCar = ListOfParkedCar.Find(car => car.CarNumber == carNumber);

        if (parkedCar != null)
        {
            parkedCar.ExitTime = DateTime.Now;
            return true;
        }
        return false;
    }
}
    