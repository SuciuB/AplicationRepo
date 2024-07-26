using System.Data.Common;
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
using Moq;
using ParkingApplication;

namespace ParkingApplication.Tests;

public class ParkingTests
{
    [Fact]
    public void AddToParking_CarParked_SlotTaken()
    {

        var expectedCarSlots = 2;
        var accountServiceMock = new Mock<IAccountService>();
        ParkingService parkingService = new ParkingService(accountServiceMock.Object, 2);

        parkingService.AddToParking(4, "abc");

        Assert.Equal(expectedCarSlots, parkingService.ListOfParkedCar.Count);
    }

    [Fact]
    public void AddToParking_SlotsAvailable_SlotsFree()
    {

        var expectedCarSlots = 3;
        var accountServiceMock = new Mock<IAccountService>();
        ParkingService parkingService = new ParkingService(accountServiceMock.Object, 4);

        parkingService.AddToParking(5, "abcewr");

        var addedCar = parkingService.ListOfParkedCar.FirstOrDefault(car => car.CarId == 5);
        Assert.Equal(expectedCarSlots , parkingService.ListOfParkedCar.Count);
        Assert.True(addedCar.InTime <= DateTime.Now);
    }

    [Fact]
    public void AddToParking_CountingObjects_CountingThroughList()
    {

        var accountServiceMock = new Mock<IAccountService>();
        ParkingService parkingService = new ParkingService(accountServiceMock.Object, 2);
        var listCount = parkingService.ListOfParkedCar.Count;

        parkingService.AddToParking(6, "def");

        Assert.Equal(listCount , parkingService.ListOfParkedCar.Count);
    }

    [Fact]
    public void ExitParking_ExitingParking_ExitParkingDate()
    {
        var boolResult = true;
        
        var accountServiceMock = new Mock<IAccountService>();
        accountServiceMock.Setup(x => x.PayForParking(1, It.IsAny<DateTime>())).Returns(true);
        ParkingService parkingService = new ParkingService(accountServiceMock.Object, 2);

        var result = parkingService.ExitParking("abc");

        Assert.Equal(boolResult , result);
    }
    
    [Fact]
    public void ExitParking_CkeckingForCarNumber_CarStillParked()
    {
        var boolResult = false;
        var accountServiceMock = new Mock<IAccountService>();
        accountServiceMock.Setup(x => x.PayForParking(2, It.IsAny<DateTime>())).Returns(false);
        ParkingService parkingService = new ParkingService(accountServiceMock.Object, 2);

        var result = parkingService.ExitParking("abcred");

        Assert.Equal(boolResult , result);
    }
}
