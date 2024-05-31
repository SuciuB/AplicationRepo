using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace ParckingApplication;

public class Parking
{   
    public int MaxSlots = 4;
    

    public List<ParckedCar> ListOfParckedCar = new List<ParckedCar> { new ParckedCar("Bogdan", DateTime.Now, "abc"), new ParckedCar("Andrei", DateTime.Now,  "abcdf")};
    

    public void AddFunction(string userName, DateTime inTime,string? carNumber = null)
    {
        if(ListOfParckedCar.Count < MaxSlots && carNumber != null)
        {
            var Car = new ParckedCar(userName, inTime, carNumber);
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
        
    public double CalculateAmount(string carNumber)
    {
        var parkedCar = ListOfParckedCar.Find(car => car.CarNumber == carNumber);
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