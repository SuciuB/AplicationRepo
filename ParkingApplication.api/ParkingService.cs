using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using ParkingApplication;

namespace ParkingApplication;

public class ParkingService : IParkingService
{      

    public int MaxSlots { get; set; }

    private readonly IAccountService _accountService;

    public ParkingService(IAccountService accountService)
    {
        _accountService = accountService;
        MaxSlots = 50;
    }

    public List<ParkingModel> ListOfParkedCar { get; } = new List<ParkingModel>  { new ParkingModel(1, "abc"), new ParkingModel(2, "abcde") };

    public void AddToParking(int id, string carNumber)
    {
        if(ListOfParkedCar.Count < MaxSlots && carNumber != null)
        {
            var Car = new ParkingModel(id, carNumber);
            ListOfParkedCar.Add(Car);

        }
    }


    public bool ExitParking(string carNumber)
    {
        var parkedCar = ListOfParkedCar.Find(car => car.CarNumber == carNumber);

        if (parkedCar != null && _accountService.PayForParking(1, parkedCar.InTime))
        {
            parkedCar.ExitTime = DateTime.Now;
            return true;
        }
        return false;
    }
}
    