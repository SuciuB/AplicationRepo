using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication.Api.Models;

public class AccountModel
{
    public int AccountId { get; set; }
    public double Money { get; set; }
    public int UserId { get; set; }

    public AccountModel(int accountId, double money, int userId)
    {
        AccountId = accountId;
        UserId = userId;
        Money = money;
    }
}