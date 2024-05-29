using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace ParckingApplication;

public class Parking
{   
    public int MaxSlots = 4;
    

    public List<ParckedCar> ListOfParckedCar = new List<ParckedCar> { new ParckedCar("Bogdan", "abc"), new ParckedCar("Andrei", "abcd")};
    

    public void AddFunction(string userName,string? carNumber = null)
    {
        if(ListOfParckedCar.Count < MaxSlots && carNumber != null)
        {
            var Car = new ParckedCar(userName, carNumber);
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
        
    public void CalculateAmount(string carNumber)
    {
        var parkedCar = ListOfParckedCar.Find(car => car.CarNumber == carNumber);
            if (parkedCar != null)
            {
                TimeSpan duration = parkedCar.ExitTime.Value - parkedCar.InTime;
                double amount = CalculateParkingFee(duration);
                Console.WriteLine($"Car {parkedCar.CarNumber} parked by {parkedCar.UserName} owes {amount:C}.");
            }
            else
            {
                Console.WriteLine($"Car is not found.");
            }
    }
    private double CalculateParkingFee(TimeSpan duration)
    {
        const double ratePerHour = 5.0; // Assuming $5 per hour rate
        return Math.Floor(duration.TotalHours) * ratePerHour;
    }
}