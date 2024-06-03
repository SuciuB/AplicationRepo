using System.Xml;
using System.Data.SqlTypes;
using System.Data;
using System.Globalization;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using ParckingApplication;

namespace ParckingApplication.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // // Arrange
        //var result = 3;
        var expectedResult = 3;
        Parking parcking = new Parking();

        // Act
        parcking.AddFunction("Vasile", "abc");
        // Assert
        Assert.Equal(expectedResult, parcking.ListOfParkedCar.Count);
    }

    [Fact]
    public void Test2()
    {
        // // Arrange
        //var result = 3;
         Parking parcking = new Parking();
         parcking.MaxSlots = 2;
         var listCount = parcking.ListOfParkedCar.Count;
        // Act
        parcking.AddFunction("Tudor","abc");
        // Assert
        Assert.Equal(listCount , parcking.ListOfParkedCar.Count);
    }

    [Fact]
    public void Test3()
    {
        // // Arrange
        //var result = 3;
        Parking parcking = new Parking();
        var listCount = parcking.ListOfParkedCar.Count;
        // Act
        parcking.AddFunction("Tudor");
        // Assert
        Assert.Equal(listCount , parcking.ListOfParkedCar.Count);
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
}