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

public class ParkingTests
{
    [Fact]
    public void AddToParking_CarParked_SlotTaken()
    {

        var expectedCarSlots = 2;
        Parking parking = new Parking(3);

        parking.AddToParking(4,"Vasile", "abc");

        Assert.Equal(expectedCarSlots, parking.ListOfParkedCar.Count);
    }

    [Fact]
    public void AddToParking_SlotsAvailable_SlotsFree()
    {

         Parking parking = new Parking(2);
         var listCount = parking.ListOfParkedCar.Count;

        parking.AddToParking(5, "Tudor","abc");

        Assert.Equal(listCount , parking.ListOfParkedCar.Count);
    }

    [Fact]
    public void AddToParking_CountingObjects_CountingThroughList()
    {

        Parking parking = new Parking(2);
        var listCount = parking.ListOfParkedCar.Count;

        parking.AddToParking(6, "Tudor");

        Assert.Equal(listCount , parking.ListOfParkedCar.Count);
    }
}