using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ParckingApplication
{
    public class Account
    {
        public Account(int money, int id)
        {
            Money = money;
            Id = id;
        }

        public int Money { get; set; }
        public int Id { get; set; }
    }
}