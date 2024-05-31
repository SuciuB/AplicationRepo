using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace ParckingApplication;

public class Parking
{   
    public int MaxSlots = 4;
    

    public List<ParkedCar> ListOfParkedCar = new List<ParkedCar> { new ParkedCar("Bogdan",  "abc" ), new ParkedCar("Andrei",  "abcde")};
    

    public void AddFunction(string userName,string? carNumber = null)
    {
        if(ListOfParkedCar.Count < MaxSlots && carNumber != null)
        {
                var Car = new ParkedCar(userName, carNumber);
                ListOfParkedCar.Add(Car);
        }
    }
    public void ExitFunction(string carNumber)
    {
        var parkedCar = ListOfParkedCar.Find(car => car.CarNumber == carNumber);
        if (parkedCar != null)
        {
            parkedCar.ExitTime = DateTime.Now;
        }
    }
        
    public double CalculateAmount(string carNumber)
    {
        var parkedCar = ListOfParkedCar.Find(car => car.CarNumber == carNumber);
        if (parkedCar != null)
        {
            TimeSpan duration = DateTime.Now - parkedCar.InTime;
            double amount = CalculateParkingFee(duration);
            return amount;
        }
        else
        {
            return 0;
        }
    }
    public double CalculateParkingFee(TimeSpan duration)
    {
        const double ratePerHour = 5.0; // Assuming $5 per hour rate
        return Math.Floor(duration.TotalHours) * ratePerHour;
    }
}