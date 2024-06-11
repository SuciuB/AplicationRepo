using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication
{
    public class ParkingModel
    {
        public int CarId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarNumber { get; set; }
        public DateTime ExitTime { get; set; }

        public ParkingModel(int carId, string firstName, string lastName, string carNumber)
        {
            CarId = carId;
            FirstName = firstName;
            LastName = lastName;
            CarNumber = carNumber;
            ExitTime = DateTime.Now;
        }

    }
}