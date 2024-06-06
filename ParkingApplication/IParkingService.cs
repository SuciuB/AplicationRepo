using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication
{
    public interface IParkingService
    {
        public int MaxSlots { get; set; }   

        public void AddToParking(int id, string userName,string? carNumber = null);
        public void ExitParking(string carNumber);
        public double CalculateAmount(string carNumber);
        public double CalculateParkingFee(TimeSpan duration);
        public bool PayForParking(string carNumber);
    }
}