using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication.Api.Models;

public class ParkingModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string CarNumber { get; set; }
    public DateTime InTime { get; set; }
    public DateTime? ExitTime { get; set; }

    public ParkingModel(int id, string carNumber, int userId)
    {
        UserId = userId;
        Id = id;
        CarNumber = carNumber;
        InTime = DateTime.Now;
        ExitTime = null;
    }
}