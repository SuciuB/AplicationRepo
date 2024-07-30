using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Models;
using ParkingApplication.Api.Repositories;

namespace ParkingApplication.Services;

public class ParkingService : IParkingService
{      

    public int MaxSlots { get; set; }

    private readonly ICommandRepository<ParkingModel> _commandRepository;
    private readonly IQueryRepository<ParkingModel> _queryRepository;
    private readonly IAccountService _accountService;

    public ParkingService(IAccountService accountService)
    {
        _queryRepository = new ParkingRepository();
        _commandRepository = new ParkingRepository();
        _accountService = accountService;
        MaxSlots = 50;
    }
    public List<ParkingModel> GetAllCars()
    {
        return _queryRepository.GetAll();
    }

    public void AddParking(ParkingModel parkingModel)
    {
        _commandRepository.Create(parkingModel);
    }

    public void RemoveParking(ParkingModel parkingModel)
    {
        _commandRepository.Delete(parkingModel);
    }

    // public List<ParkingModel> GetParkedCar { get; } = new List<ParkingModel>  { new ParkingModel(1, "abc"), new ParkingModel(2, "abcde") };

    public void AddToParking(int userId, string carNumber)
    {
        var getCars = _queryRepository.GetAll();
        if(getCars.Count < MaxSlots && carNumber != null)
        {
            var Car = new ParkingModel(userId, carNumber);
            _commandRepository.Create(Car);

        }
    }

    public bool ExitParking(string carNumber)
    {
        var getCars = _queryRepository.GetAll();
        var parkedCar = getCars.Find(car => car.CarNumber == carNumber);

        if (parkedCar != null && _accountService.PayForParking(1, parkedCar.InTime))
        {
            parkedCar.ExitTime = DateTime.Now;
            return true;
        }
        return false;
    }
}
    