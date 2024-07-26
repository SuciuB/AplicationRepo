using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingApplication.Api.Models;

namespace ParkingApplication.Api.Interfaces
{
    public interface IParkedCarService
    {
        public int MaxSlots { get; set; }
        public string CarNumber { get; set; }
        public DateTime InTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public int Id { get; set; }
    }
}