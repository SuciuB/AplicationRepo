using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication.Services
{
    public class Account : IAccountService
    {

        public List<ParkedCar> ListOfParkedCar = new List<ParkedCar> { new ParkedCar(1, "Bogdan",  "abc"), new ParkedCar(2, "Andrei",  "abcde")};
        public List<Account> ListOfAccounts = new List<Account> {new Account(1, 500), new Account(2, 200)};

        public Account(int id, double money)
        {
            Money = money;
            Id = id;
        }
        public int MaxSlots { get; set; }
        public double Money { get; set; }
        public int Id { get; set; }

        public double CalculateParkingFee(TimeSpan duration)
        {
            const double ratePerHour = 5.0; // Assuming $5 per hour rate

            if(duration.Hours <= 1)
            {
                return 0;
            }
            var payableHours = duration.Hours -1;
            var calculatePayment =  payableHours * ratePerHour;
            return calculatePayment;
        
        }

        public void ExitParking(string carNumber)
    {
            var parkedCar = ListOfParkedCar.Find(car => car.CarNumber == carNumber);
            if (parkedCar != null && PayForParking(carNumber) == true)
            {
                parkedCar.ExitTime = DateTime.Now;
            }
    }

        public double CalculateAmount(string carNumber)
        {
            var parkedCar = ListOfParkedCar.Find(car => car.CarNumber == carNumber);
            if (parkedCar != null)
            {
                TimeSpan duration = DateTime.Now - parkedCar.InTime;
                double amount = CalculateParkingFee(duration);
                return amount;
                
            }
            else
            {
                return 0;
            }
        }

        public bool PayForParking(string carNumber)
        {
            var parkedCar = ListOfParkedCar.Find(car => car.CarNumber == carNumber);
            
            double amountToPay = CalculateAmount(carNumber);

            var account = ListOfAccounts.Find(acc => acc.Id == parkedCar.Id);

            if (account.Money >= amountToPay)

            {
                account.Money -= amountToPay;
                return true;
            }
        
                return false;

        }
    }

}