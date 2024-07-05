using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication
{
    public interface IAccountService
    {
        public bool PayForParking(int carId, DateTime inTime);
    }
}