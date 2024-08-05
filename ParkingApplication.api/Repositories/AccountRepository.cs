using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Models;

namespace Repositories;
public class AccountRepository : IQueryRepository<AccountModel>
{
private readonly List<AccountModel> _accounts = new List<AccountModel>
{
    new AccountModel(1, 500, 1),
    new AccountModel(2, 200, 2)
};

public List<AccountModel> GetAll()
{
    return _accounts;
}
}
