using System.Security.Cryptography;
using System.Threading.Tasks.Dataflow;
using System.Xml;
using System.Data.SqlTypes;
using System.Data;
using System.Globalization;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using Xunit;
using ParkingApplication;

namespace ParkingApplication.Tests
{
    public class AccountTests
    {
        [Fact]
        public void PayForParking_AmountToPay_PayForHoursParked()
        {

            var boolResult = true;
            AccountService accountService = new AccountService();

            var result = accountService.PayForParking(2, DateTime.Now.AddHours(-4));

            Assert.Equal(boolResult, result);
        }

        [Fact]
        public void PayForParking_AmountToPay_NotHavingMoney()
        {

            var boolResult = false;
            AccountService accountService = new AccountService();
            AccountModel accountModel = new AccountModel(3, 10, 3);
            accountService.ListOfAccounts.Add(accountModel);

            var result = accountService.PayForParking(3, DateTime.Now.AddHours(-4));

            Assert.Equal(boolResult, result);
        }
        [Fact]
        public void PayForParking_AmountToPay_NullId()
        {

            var boolResult = false;
            AccountService accountService = new AccountService();

            var result = accountService.PayForParking(3, DateTime.Now);

            Assert.Equal(boolResult, result);
        }

        // [Fact]
        // public void CalculateParkingFee_FirstHourFree_ReturnSameAmount()
        // {

        //     var firstHourResult = 0;
        //     AccountService accountService = new AccountService();
        //     AccountModel accountModel = new AccountModel(3, 10, 3);
        //     accountService.ListOfAccounts.Add(accountModel);

        //     var result = accountService.PayForParking(3, DateTime.Now.AddHours(-1));

        //     Assert.Equal(firstHourResult, result);
        // }

    // [Fact]
    //     public void CalculateAmount_NothingToPay_NoPayment()
    //     {

    //         var expectedAmount = 0;
    //         AccountService accountService = new AccountService();
    //         AccountModel accountModel = new AccountModel(3, 100);
    //         ParkedCar parkedCar = new ParkedCar(3, "Tudor", "def", DateTime.Now);
    //         accountService.ListOfAccounts.Add(accountModel);
    //         accountService.ListOfParkedCar.Add(parkedCar);

    //         var result = accountService.CalculateAmount("def");

    //         Assert.Equal(expectedAmount ,result);
    //     }

    // [Fact]
    //     public void CalculateAmount_FirstHour_FirstOurFree()
    //     {

    //         var expectedAmount = 0;
    //         AccountService accountService = new AccountService();
    //         AccountModel accountModel = new AccountModel(3, 100);
    //         ParkedCar parkedCar = new ParkedCar(3, "Tudor", "def", DateTime.Now.AddMinutes(-1));
    //         accountService.ListOfAccounts.Add(accountModel);
    //         accountService.ListOfParkedCar.Add(parkedCar);

    //         var result = accountService.CalculateAmount("def");

    //         Assert.Equal(expectedAmount ,result);
    //     }
    //     [Fact]
    // public void PayForParking_RemoveAmount_AmountIsLess()
    // {

    //     var expectedAmount = 380;
    //     bool boolResult = true;
    //     // Parking parking = new Parking();
    //     AccountService accountService = new AccountService();
    //     AccountModel accountModel = new AccountModel(4, 400);
    //     ParkedCar parkedCar = new ParkedCar(4, "Tudor", "def", DateTime.Now.AddHours(-5));
    //     accountService.ListOfAccounts.Add(accountModel);
    //     accountService.ListOfParkedCar.Add(parkedCar);

    //     var result = accountService.PayForParking("def");

    //     Assert.Equal(expectedAmount , accountModel.Money);
    //     Assert.Equal(boolResult, result);
    // }

    // [Fact]
    // public void PayForParking_NotEnoughAmount_AmountNotChange()
    // {

    //     var expectedAmount = 10;
    //     bool boolResult = false;
    //     // Parking parking = new Parking();
    //     ParkedCar parkedCar = new ParkedCar(3, "Tudor", "def", DateTime.Now.AddHours(-4));
    //     AccountService accountService = new AccountService();
    //     AccountModel accountModel = new AccountModel(3, 10);
    //     accountService.ListOfAccounts.Add(accountModel);
    //     accountService.ListOfParkedCar.Add(parkedCar);

    //     var result = accountService.PayForParking("def");

    //     Assert.Equal(expectedAmount , accountModel.Money);
    //     Assert.Equal(boolResult , result);
    // }
    }
}