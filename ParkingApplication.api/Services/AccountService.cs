using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Models;
using Repositories;

namespace ParkingApplication.Services;
public class AccountService : IAccountService
{

private readonly IQueryRepository<AccountModel> _queryRepository;

public AccountService(IQueryRepository<AccountModel> queryRepository = null)
{
    if(queryRepository == null)
    {
        queryRepository = new AccountRepository();
    }
    _queryRepository = queryRepository;
}
public List<AccountModel> GetAllCars()
    {
        return _queryRepository.GetAll();
    }

public bool PayForParking(int userId, DateTime inTime)
{
    TimeSpan duration = DateTime.Now - inTime;

    double amountToPay = CalculateParkingFee(duration);

    var getAccount = _queryRepository.GetAll();
    var accountList = getAccount.Where(acc => acc.UserId == userId);

    foreach(var account in accountList)
    {
        if (accountList != null && account.Money >= amountToPay)
        {
            account.Money -= amountToPay;

            return true;
        } 
    }
            return false;
}
public double CalculateParkingFee(TimeSpan duration)
{
    const double ratePerHour = 5.0;

    if(duration.Hours <= 1)
    {
        return 0;
    }

    var payableHours = duration.Hours -1;
    var calculatePayment =  payableHours * ratePerHour;

    return calculatePayment;
}
}