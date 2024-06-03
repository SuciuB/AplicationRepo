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
    public void Test1()
    {
        // // Arrange
        //var result = 3;
        var expectedResult = 3;
        Parking parking = new Parking();

        // Act
        parking.AddToParking("Vasile", "abc");
        // Assert
        Assert.Equal(expectedResult, parking.ListOfParkedCar.Count);
    }

    [Fact]
    public void Test2()
    {
        // // Arrange
        //var result = 3;
         Parking parking = new Parking();
         parking.MaxSlots = 2;
         var listCount = parking.ListOfParkedCar.Count;
        // Act
        parking.AddToParking("Tudor","abc");
        // Assert
        Assert.Equal(listCount , parking.ListOfParkedCar.Count);
    }

    [Fact]
    public void Test3()
    {
        // // Arrange
        //var result = 3;
        Parking parking = new Parking();
        var listCount = parking.ListOfParkedCar.Count;
        // Act
        parking.AddToParking("Tudor");
        // Assert
        Assert.Equal(listCount , parking.ListOfParkedCar.Count);
    }

    [Fact]
    public void Test4()
    {
        // // Arrange
        var expectedResul = 15;
        Parking parking = new Parking();
        ParkedCar parkedCar = new ParkedCar("Tudor", "def", DateTime.Now.AddHours(-3));
        parking.ListOfParkedCar.Add(parkedCar);
        // Act
        var result = parking.CalculateAmount("def");
        // Assert
        Assert.Equal(expectedResul ,result);
    }

    [Fact]
    public void Test5()
    {
        // // Arrange
        var expectedResul = 0;
        Parking parking = new Parking();
        ParkedCar parkedCar = new ParkedCar("Tudor", "def", DateTime.Now);
        parking.ListOfParkedCar.Add(parkedCar);
        // Act
        var result = parking.CalculateAmount("def");
        // Assert
        Assert.Equal(expectedResul ,result);
    }

    [Fact]
    public void Test6()
    {
        // // Arrange
        var expectedResul = 0;
        Parking parking = new Parking();
        ParkedCar parkedCar = new ParkedCar("Tudor", "def", DateTime.Now.AddMinutes(-5));
        parking.ListOfParkedCar.Add(parkedCar);
        // Act
        var result = parking.CalculateAmount("def");
        // Assert
        Assert.Equal(expectedResul ,result);
    }

    [Fact]
    public void Test7()
    {
        // // Arrange
        var expectedResul = 5;
        Parking parking = new Parking();
        ParkedCar parkedCar = new ParkedCar("Tudor", "def", DateTime.Now.AddHours(-1).AddMinutes(-5));
        parking.ListOfParkedCar.Add(parkedCar);
        // Act
        var result = parking.CalculateAmount("def");
        // Assert
        Assert.Equal(expectedResul ,result);
    }
    
}