using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication
{
    public class Account
    {
        public Account(int id, double money)
        {
            Money = money;
            Id = id;
        }

        public double Money { get; set; }
        public int Id { get; set; }
    }
}