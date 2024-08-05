using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Models;

namespace ParkingApplication.Api.Repositories;
public class ParkingRepository : IQueryRepository<ParkingModel>, ICommandRepository<ParkingModel>
{
private List<ParkingModel> _parkedCars = new List<ParkingModel>
{
    new ParkingModel(1, "abc", 1),
    new ParkingModel(2, "abcde", 2)
};

public List<ParkingModel> GetAll()
{
    return _parkedCars;
}

public ParkingModel GetByCarNumber(string carNumber)
{
    return _parkedCars.Find(car => car.CarNumber == carNumber);
}

public void Create(ParkingModel parkingModel)
{
        _parkedCars.Add(parkingModel);
}

public void Delete(ParkingModel parkingModel)
{
    _parkedCars.Remove(parkingModel);
}

}