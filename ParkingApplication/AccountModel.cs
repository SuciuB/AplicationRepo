using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication
{
    public class AccountModel
    {
        public int Id { get; set; }
        public double Money { get; set; }
        public int UserId { get; set; }

    public AccountModel(int id, double money, int userId)
    {
        Id = id;
        Money = money;
        UserId = userId;
    }
    }
}