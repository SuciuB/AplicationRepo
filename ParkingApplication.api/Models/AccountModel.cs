using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication.Api.Models;

public class AccountModel
{
    public int AccountId { get; set; }
    public double Amount { get; set; }
    public int UserId { get; set; }

    public AccountModel(int accountId, double amount, int userId)
    {
        AccountId = accountId;
        UserId = userId;
        Amount = amount;
    }
}