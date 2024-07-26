using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingApplication.Api.Interfaces;

namespace Repositories
{
    public class ParkingRepository : IQueryRepository<ParkingModel>, ICommandsRepository
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

        public void Delete(int id)
        {
            var parkedCar = _parkedCars.FirstOrDefault(p => p.Id = id);
            if(parkedCar != null)
            {
                _parkedCars.Remove(parkedCar);
            }
        }

    }
}