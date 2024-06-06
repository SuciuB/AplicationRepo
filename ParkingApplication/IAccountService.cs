using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication
{
    public interface IAccountService
    {
        public int MaxSlots { get; set; }
        public double Money { get; set; }
        public int Id { get; set; }
    }
}