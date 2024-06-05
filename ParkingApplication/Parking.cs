using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace ParkingApplication;

public class Parking
{   
    public int MaxSlots = 4;
    

    public List<ParkedCar> ListOfParkedCar = new List<ParkedCar> { new ParkedCar(1, "Bogdan",  "abc"), new ParkedCar(2, "Andrei",  "abcde")};
    public List<Account> ListOfAccounts = new List<Account> {new Account(1, 500), new Account(2, 200)};
    

    public void AddToParking(int id, string userName,string? carNumber = null)
    {
        if(ListOfParkedCar.Count < MaxSlots && carNumber != null)
        {
                var Car = new ParkedCar(id, userName, carNumber);
                ListOfParkedCar.Add(Car);
        }
    }
    public void ExitParking(string carNumber)
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
        var totalHours = Math.Ceiling(duration.TotalHours);

        if(totalHours <= 1)
        {
            return 0;
        }
        var payableHours = totalHours -1;
        var calculatePayment =  payableHours * ratePerHour;
        return calculatePayment;
        
    }

    public void PayForParking(string carNumber)
    {
        var parkedCar = ListOfParkedCar.Find(car => car.CarNumber == carNumber);
        
        double amountToPay = CalculateAmount(carNumber);

        var account = ListOfAccounts.Find(acc => acc.Id == parkedCar.Id);

        if (account.Money >= amountToPay)

        {
            account.Money -= amountToPay;
        }
        

    }

}

    