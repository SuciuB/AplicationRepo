using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication
{
    public class AccountService : IAccountService
    {
        public List<AccountModel> ListOfAccounts = new List<AccountModel> {new AccountModel(1, 500, 1), new AccountModel(2, 200, 2)};


        public bool PayForParking(int userId, DateTime inTime)
        {
            TimeSpan duration = DateTime.Now - inTime;

            double amountToPay = CalculateParkingFee(duration);

            var account = ListOfAccounts.Find(acc => acc.AccountId == userId);

            if (account == null || account.Money < amountToPay) return false;
            
            account.Money -= amountToPay;

            return true;
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

}