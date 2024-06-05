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

namespace ParkingApplication.Tests;

public class UnitTest1
{
    [Fact]
    public void AddToParking_CarParked_SlotTaken()
    {
        // // Arrange
        //var result = 3;
        var expectedResult = 3;
        Parking parking = new Parking();

        // Act
        parking.AddToParking(4,"Vasile", "abc");
        // Assert
        Assert.Equal(expectedResult, parking.ListOfParkedCar.Count);
    }

    [Fact]
    public void AddToParking_SlotsAvailable_SlotsFree()
    {
        // // Arrange
        //var result = 3;
         Parking parking = new Parking();
         parking.MaxSlots = 2;
         var listCount = parking.ListOfParkedCar.Count;
        // Act
        parking.AddToParking(5, "Tudor","abc");
        // Assert
        Assert.Equal(listCount , parking.ListOfParkedCar.Count);
    }

    [Fact]
    public void AddToParking_CountingObjects_CountingThroughList()
    {
        // // Arrange
        //var result = 3;
        Parking parking = new Parking();
        var listCount = parking.ListOfParkedCar.Count;
        // Act
        parking.AddToParking(6, "Tudor");
        // Assert
        Assert.Equal(listCount , parking.ListOfParkedCar.Count);
    }

    [Fact]
    public void CalculateAmount_AmountToPay_PayForHoursParked()
    {
        // // Arrange
        var expectedResul = 15;
        Parking parking = new Parking();
        ParkedCar parkedCar = new ParkedCar(1,"Tudor", "def", DateTime.Now.AddHours(-4));
        parking.ListOfParkedCar.Add(parkedCar);
        // Act
        var result = parking.CalculateAmount("def");
        // Assert
        Assert.Equal(expectedResul ,result);
    }

    [Fact]
    public void CalculateAmount_NothingToPay_NoPayment()
    {
        // // Arrange
        var expectedResul = 0;
        Parking parking = new Parking();
        ParkedCar parkedCar = new ParkedCar(8, "Tudor", "def", DateTime.Now);
        parking.ListOfParkedCar.Add(parkedCar);
        // Act
        var result = parking.CalculateAmount("def");
        // Assert
        Assert.Equal(expectedResul ,result);
    }

    [Fact]
    public void CalculateAmount_FirstHour_FirstOurFree()
    {
        // // Arrange
        var expectedResul = 0;
        Parking parking = new Parking();
        ParkedCar parkedCar = new ParkedCar(10, "Tudor", "def", DateTime.Now.AddMinutes(-5));
        parking.ListOfParkedCar.Add(parkedCar);
        // Act
        var result = parking.CalculateAmount("def");
        // Assert
        Assert.Equal(expectedResul ,result);
    }
    
    [Fact]
    public void PayForParking_RemoveAmount_AmountIsLess()
    {
        // // Arrange
        var expectedResul = 380;
        bool boolResult = true;
        Parking parking = new Parking();
        ParkedCar parkedCar = new ParkedCar(3, "Tudor", "def", DateTime.Now.AddHours(-5));
        Account account = new Account(3, 400);
        parking.ListOfAccounts.Add(account);
        parking.ListOfParkedCar.Add(parkedCar);
        // Act
        var result = parking.PayForParking("def");
        // Assert
        Assert.Equal(expectedResul , account.Money);
        Assert.Equal(boolResult, result);
    }

    [Fact]
    public void PayForParking_NotEnoughAmount_AmountNotChange()
    {
        // // Arrange
        var expectedResul = 10;
        bool boolResult = false;
        Parking parking = new Parking();
        ParkedCar parkedCar = new ParkedCar(3, "Tudor", "def", DateTime.Now.AddHours(-4));
        Account account = new Account(3, 10);
        parking.ListOfAccounts.Add(account);
        parking.ListOfParkedCar.Add(parkedCar);
        // Act
        var result = parking.PayForParking("def");
        // Assert
        Assert.Equal(expectedResul , account.Money);
        Assert.Equal(boolResult , result);
    }
}