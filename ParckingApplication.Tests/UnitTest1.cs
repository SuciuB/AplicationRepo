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
        parcking.AddFunction("Vasile",DateTime.Now, "abc");
        // Assert
        Assert.Equal(expectedResult, parcking.ListOfParckedCar.Count);
    }

    [Fact]
    public void Test2()
    {
        // // Arrange
        //var result = 3;
         Parking parcking = new Parking();
         parcking.MaxSlots = 2;
         var listCount = parcking.ListOfParckedCar.Count;
        // Act
        parcking.AddFunction("Tudor",DateTime.Now, "abc");
        // Assert
        Assert.Equal(listCount , parcking.ListOfParckedCar.Count);
    }

    [Fact]
    public void Test3()
    {
        // // Arrange
        //var result = 3;
        Parking parcking = new Parking();
        var listCount = parcking.ListOfParckedCar.Count;
        // Act
        parcking.AddFunction("Tudor", DateTime.Now);
        // Assert
        Assert.Equal(listCount , parcking.ListOfParckedCar.Count);
    }
    [Fact]
    public void Test4()
    {
        // // Arrange
        var result = 15;
        Parking parcking = new Parking();
        // Act
        parcking.AddFunction("Ionel", DateTime.Now.AddHours(-3), "ab");
        // Assert
        Assert.Equal(result ,parcking.CalculateAmount("ab"));
    }
}