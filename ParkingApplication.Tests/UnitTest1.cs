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
    public void CarParked()
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
    public void SlotsAvailable()
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
    public void CountingObjects()
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
    public void AmountToPay()
    {
        // // Arrange
        var expectedResul = 15;
        Parking parking = new Parking();
        ParkedCar parkedCar = new ParkedCar(1,"Tudor", "def", DateTime.Now.AddHours(-3));
        parking.ListOfParkedCar.Add(parkedCar);
        // Act
        var result = parking.CalculateAmount("def");
        // Assert
        Assert.Equal(expectedResul ,result);
    }

    [Fact]
    public void NothingToPay()
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
    public void FirstHour()
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
    public void SecondOurPay()
    {
        // // Arrange
        var expectedResul = 5;
        Parking parking = new Parking();
        ParkedCar parkedCar = new ParkedCar(11, "Tudor", "def", DateTime.Now.AddHours(-1).AddMinutes(-5));
        parking.ListOfParkedCar.Add(parkedCar);
        // Act
        var result = parking.CalculateAmount("def");
        // Assert
        Assert.Equal(expectedResul ,result);
    }
    
    [Fact]
    public void RemoveAmount()
    {
        // // Arrange
        var expectedResul = 385;
        Parking parking = new Parking();
        ParkedCar parkedCar = new ParkedCar(3, "Tudor", "def", DateTime.Now.AddHours(-3));
        Account account = new Account(3, 400);
        parking.ListOfAccounts.Add(account);
        parking.ListOfParkedCar.Add(parkedCar);
        // Act
        parking.PayForParking("def");
        // Assert
        Assert.Equal(expectedResul , account.Money);
    }

    [Fact]
    public void NotEnoughAmount()
    {
        // // Arrange
        var expectedResul = 10;
        Parking parking = new Parking();
        ParkedCar parkedCar = new ParkedCar(3, "Tudor", "def", DateTime.Now.AddHours(-3));
        Account account = new Account(3, 10);
        parking.ListOfAccounts.Add(account);
        parking.ListOfParkedCar.Add(parkedCar);
        // Act
        parking.PayForParking("def");
        // Assert
        Assert.Equal(expectedResul , account.Money);
    }
}