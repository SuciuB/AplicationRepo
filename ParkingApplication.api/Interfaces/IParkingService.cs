using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingApplication.Api.Models;

namespace ParkingApplication.Api.Interfaces
{
    public interface IParkingService
    {
        public int MaxSlots { get; set; }   
        public void AddToParking(int id, string carNumber, int userId);
        public bool ExitParking(string carNumber);
        void AddParking(ParkingModel parkingModel);
        void RemoveParking(ParkingModel parkingModel);
        List<ParkingModel> GetAllCars();
    }
}