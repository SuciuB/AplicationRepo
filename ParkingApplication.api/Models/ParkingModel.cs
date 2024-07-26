using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication.Api.Models;

public class ParkingModel
{
    public int UserId { get; set; }
    public string CarNumber { get; set; }
    public DateTime InTime { get; set; }
    public DateTime? ExitTime { get; set; }

    public ParkingModel(int userId, string carNumber)
    {
        UserId = userId;
        CarNumber = carNumber;
        InTime = DateTime.Now;
        ExitTime = null;
    }
}