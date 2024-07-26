using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication.Api.Models;

public class AccountModel
{
    public double Money { get; set; }
    public int UserId { get; set; }

    public AccountModel(int userId, double money)
    {
        UserId = userId;
        Money = money;
    }
}