using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication
{
    public interface IAccountService
    {
        List<AccountModel> ListOfAccounts { get; }
        public bool PayForParking(int carId, DateTime inTime);
    }
}