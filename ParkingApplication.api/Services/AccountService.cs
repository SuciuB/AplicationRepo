using System;
using System.Collections.Generic;
using System.Linq;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Models;

namespace ParkingApplication.Services;
public class AccountService : IAccountService
{
private readonly IQueryRepository<AccountModel> _queryRepository;

public AccountService(IRepositoryFactory repositoryFactory)
{
    _queryRepository = repositoryFactory.CreateQueryRepository<AccountModel>();
}

public List<AccountModel> GetAllAccounts()
{
    return _queryRepository.GetAll();
}

public bool PayForParking(int userId, DateTime inTime)
{
    TimeSpan duration = DateTime.Now - inTime;
    double amountToPay = CalculateParkingFee(duration);

    var accountList = _queryRepository.GetAll().Where(acc => acc.UserId == userId);

    foreach (var account in accountList)
    {
        if (account.Amount >= amountToPay)
        {
            account.Amount -= amountToPay;
            return true;
        }
    }

    return false;
}

public double CalculateParkingFee(TimeSpan duration)
{
    const double ratePerHour = 5.0;

    if (duration.Hours <= 1)
    {
        return 0;
    }

    var payableHours = duration.Hours - 1;
    return payableHours * ratePerHour;
}
}
