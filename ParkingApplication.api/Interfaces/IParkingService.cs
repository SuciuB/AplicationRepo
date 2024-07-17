using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingApplication.Models;

namespace ParkingApplication.Interfaces
{
    public interface IParkingService
    {

        List<ParkingModel> ListOfParkedCar { get; }
        public int MaxSlots { get; set; }   
        public void AddToParking(int id, string carNumber);
        public bool ExitParking(string carNumber);
    }
}