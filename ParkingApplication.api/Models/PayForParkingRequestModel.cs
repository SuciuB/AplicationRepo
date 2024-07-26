using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication.Api.Models
{
    public class PayForParkingRequestModel
    {
        public int UserId { get; set; }
        public DateTime InTime { get; set; }
    }
}