using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication
{
    public class AccountModel
    {
        public int AccountId { get; set; }
        public double Money { get; set; }
        public int UserId { get; set; }

    public AccountModel(int id, double money, int userId)
    {
        AccountId = id;
        Money = money;
        UserId = userId;
    }
    }
}