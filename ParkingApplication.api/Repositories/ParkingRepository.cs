using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Models;

namespace ParkingApplication.Api.Repositories
{
    public class ParkingRepository : IQueryRepository<ParkingModel>, ICommandRepository<ParkingModel>
    {
        private List<ParkingModel> _parkedCars = new List<ParkingModel>
        {
            new ParkingModel(1, "abc"),
            new ParkingModel(2, "abcde")
        };
        
        public List<ParkingModel> GetAll()
        {
            return _parkedCars;
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
}