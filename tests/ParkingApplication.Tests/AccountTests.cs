// using System.Timers;
// using System.Security.Cryptography;
// using System.Threading.Tasks.Dataflow;
// using System.Xml;
// using System.Data.SqlTypes;
// using System.Data;
// using System.Globalization;
// using System.Runtime.Serialization;
// using System.ComponentModel;
// using System.Runtime.CompilerServices;
// using System;
// using Xunit;
// using ParkingApplication.Services;
// using ParkingApplication.Api.Interfaces;
// using ParkingApplication.Api.Models;

// namespace ParkingApplication.Tests
// {
//     public class AccountTests
//     {
//         [Fact]
//         public void PayForParking_AmountToPay_PayForHoursParked()
//         {

//             var boolResult = true;
//             AccountService accountService = new AccountService();

//             var result = accountService.PayForParking(2, DateTime.Now.AddHours(-4));

//             Assert.Equal(boolResult, result);
//         }

//         [Fact]
//         public void PayForParking_AmountToPay_NotHavingMoney()
//         {

//             var boolResult = false;
//             AccountService accountService = new AccountService();
//             AccountModel accountModel = new AccountModel(3, 10, 3);
//             accountService.ListOfAccounts.Add(accountModel);

//             var result = accountService.PayForParking(3, DateTime.Now.AddHours(-4));

//             Assert.Equal(boolResult, result);
//         }
//         [Fact]
//         public void PayForParking_AmountToPay_NullId()
//         {

//             var boolResult = false;
//             AccountService accountService = new AccountService();

//             var result = accountService.PayForParking(3, DateTime.Now);

//             Assert.Equal(boolResult, result);
//         }

//         [Fact]
//         public void CalculateParkingFee_FirstHourFree_ReturnSameAmount()
//         {

//             TimeSpan duration = TimeSpan.FromHours(1);
//             var accountService = new AccountService();

//             double fee = accountService.CalculateParkingFee(duration);

//             Assert.Equal(0 , fee);
//         }

//     }
    
// }