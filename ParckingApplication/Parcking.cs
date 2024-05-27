using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace ParckingApplication;

public class Parking
{   
    public int MaxSlots = 4;
    

    public List<ParckedCar> ListOfParckedCar = new List<ParckedCar> { new ParckedCar("Bogdan", "abc", DateTime.Now), new ParckedCar("Andrei", "abc", DateTime.Now)};
    

    public void AddFunction(string userName, DateTime inTime, string? carNumber = null)
    {
        if(ListOfParckedCar.Count < MaxSlots && carNumber != null)
        {
            var Car = new ParckedCar(userName, carNumber, inTime);
            ListOfParckedCar.Add(Car);
        }
    }
    public void ExitFunction(string carNumber, DateTime exitTime)
    {
        var parkedCar = ListOfParckedCar.Find(car => car.CarNumber == carNumber);
        if (parkedCar != null)
        {
            parkedCar.ExitTime = exitTime;
        }
    }
        
    public void CalculateAmount()
    {
        foreach (var parkedCar in ListOfParckedCar)
        {
            if (parkedCar.ExitTime.HasValue)
            {
                TimeSpan duration = parkedCar.ExitTime.Value - parkedCar.InTime;
                double amount = CalculateParkingFee(duration);
                Console.WriteLine($"Car {parkedCar.CarNumber} parked by {parkedCar.UserName} owes {amount:C}.");
            }
            else
            {
                Console.WriteLine($"Car {parkedCar.CarNumber} parked by {parkedCar.UserName} is still parked.");
            }
        }
    }
    private double CalculateParkingFee(TimeSpan duration)
    {
        const double ratePerHour = 5.0; // Assuming $5 per hour rate
        return Math.Ceiling(duration.TotalHours) * ratePerHour;
    }
}