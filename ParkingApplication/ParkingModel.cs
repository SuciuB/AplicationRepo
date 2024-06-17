using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication
{
    public class ParkingModel
    {
        public int CarId { get; set; }
        public string CarNumber { get; set; }
        public DateTime InTime { get; set; }
        public DateTime? ExitTime { get; set; }

        public ParkingModel(int carId, string carNumber)
        {
            CarId = carId;
            CarNumber = carNumber;
            InTime = DateTime.Now;
            ExitTime = null;
        }

    }
}