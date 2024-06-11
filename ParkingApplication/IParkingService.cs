using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication
{
    public interface IParkingService
    {
        public int MaxSlots { get; set; }   

        public void AddToParking(int id, string FirstName, string LastName, string carNumber);
        public bool ExitParking(string carNumber);
    }
}