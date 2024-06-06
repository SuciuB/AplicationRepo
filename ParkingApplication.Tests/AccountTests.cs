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
using ParkingApplication.Services;

namespace ParkingApplication.Tests
{
    public class AccountTests
    {
        [Fact]
        public void CalculateAmount_AmountToPay_PayForHoursParked()
        {

            var expectedAmount = 15;
            Account account = new Account(2, 100);
            ParkedCar parkedCar = new ParkedCar(1,"Tudor", "def", DateTime.Now.AddHours(-4));
            account.ListOfParkedCar.Add(parkedCar);

            var result = account.CalculateAmount("def");

            Assert.Equal(expectedAmount ,result);
        }

    [Fact]
        public void CalculateAmount_NothingToPay_NoPayment()
        {

            var expectedAmount = 0;
            Account account = new Account(2, 100);
            ParkedCar parkedCar = new ParkedCar(8, "Tudor", "def", DateTime.Now);
            account.ListOfParkedCar.Add(parkedCar);

            var result = account.CalculateAmount("def");

            Assert.Equal(expectedAmount ,result);
        }

    [Fact]
        public void CalculateAmount_FirstHour_FirstOurFree()
        {

            var expectedAmount = 0;
            Account account = new Account(2, 100);
            ParkedCar parkedCar = new ParkedCar(10, "Tudor", "def", DateTime.Now.AddMinutes(-5));
            account.ListOfParkedCar.Add(parkedCar);

            var result = account.CalculateAmount("def");

            Assert.Equal(expectedAmount ,result);
        }
        [Fact]
    public void PayForParking_RemoveAmount_AmountIsLess()
    {

        var expectedAmount = 380;
        bool boolResult = true;
        Parking parking = new Parking(2);
        Account account = new Account(4, 300);
        ParkedCar parkedCar = new ParkedCar(3, "Tudor", "def", DateTime.Now.AddHours(-5));
        account.ListOfAccounts.Add(account);
        account.ListOfParkedCar.Add(parkedCar);

        var result = account.PayForParking("def");

        Assert.Equal(expectedAmount , account.Money);
        Assert.Equal(boolResult, result);
    }

    [Fact]
    public void PayForParking_NotEnoughAmount_AmountNotChange()
    {

        var expectedAmount = 10;
        bool boolResult = false;
        Parking parking = new Parking(2);
        ParkedCar parkedCar = new ParkedCar(3, "Tudor", "def", DateTime.Now.AddHours(-4));
        Account account = new Account(3, 10);
        account.ListOfAccounts.Add(account);
        account.ListOfParkedCar.Add(parkedCar);

        var result = account.PayForParking("def");

        Assert.Equal(expectedAmount , account.Money);
        Assert.Equal(boolResult , result);
    }
    }
}