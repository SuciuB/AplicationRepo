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
using ParkingApplication.Services;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Models;
using ParkingApplication.Api.Repositories;

namespace ParkingApplication.Tests;

public class ParkingTests
{
    [Fact]
public void AddToParking_CarParked_SlotTaken()
{
    // Arrange
    var expectedCarSlots = 2;

    var queryRepositoryMock = new Mock<IQueryRepository<ParkingModel>>();
    var commandRepositoryMock = new Mock<ICommandRepository<ParkingModel>>();
    var factoryMock = new Mock<IRepositoryFactory>();

    var initialParkedCars = new List<ParkingModel>
    {
        new ParkingModel(1, "abc", 1),
        new ParkingModel(2, "abcde", 2)
    };

    queryRepositoryMock.Setup(x => x.GetAll()).Returns(initialParkedCars);
    commandRepositoryMock.Setup(x => x.Create(It.IsAny<ParkingModel>()))
        .Callback<ParkingModel>(car => initialParkedCars.Add(car));

    factoryMock.Setup(f => f.CreateQueryRepository<ParkingModel>())
               .Returns(queryRepositoryMock.Object);
    factoryMock.Setup(f => f.CreateCommandRepository<ParkingModel>())
               .Returns(commandRepositoryMock.Object);

    var accountServiceMock = new Mock<IAccountService>();
    var parkingService = new ParkingService(accountServiceMock.Object, factoryMock.Object);
    parkingService.MaxSlots = 2;

    // Act
    parkingService.AddToParking(3, "abcew", 3);

    // Assert
    Assert.Equal(expectedCarSlots, parkingService.GetAllCars().Count);
}


[Fact]
public void AddToParking_SlotsAvailable_SlotsFree()
{
    // Arrange
    var expectedCarSlots = 3;
    var accountServiceMock = new Mock<IAccountService>();
    var commandRepositoryMock = new Mock<ICommandRepository<ParkingModel>>();
    var queryRepositoryMock = new Mock<IQueryRepository<ParkingModel>>();
    var factoryMock = new Mock<IRepositoryFactory>();

    var initialParkedCars = new List<ParkingModel>
    {
        new ParkingModel(1, "abc", 1),
        new ParkingModel(2, "abcde", 2)
    };

    queryRepositoryMock.Setup(x => x.GetAll()).Returns(initialParkedCars);
    commandRepositoryMock.Setup(x => x.Create(It.IsAny<ParkingModel>())).Callback<ParkingModel>(car => initialParkedCars.Add(car));

    factoryMock.Setup(f => f.CreateQueryRepository<ParkingModel>())
               .Returns(queryRepositoryMock.Object);
    factoryMock.Setup(f => f.CreateCommandRepository<ParkingModel>())
               .Returns(commandRepositoryMock.Object);

    ParkingService parkingService = new ParkingService(accountServiceMock.Object, factoryMock.Object);
    
    // Act
    parkingService.AddToParking(4, "abcew", 3);

    // Assert
    commandRepositoryMock.Verify(repo => repo.Create(It.IsAny<ParkingModel>()), Times.Once);
    Assert.Equal(expectedCarSlots, parkingService.GetAllCars().Count);
}



[Fact]
public void ExitParking_ExitingParking_ExitParkingDate()
{
    //Arrange
    var boolResult = true;
    var accountServiceMock = new Mock<IAccountService>();
    var commandRepositoryMock = new Mock<ICommandRepository<ParkingModel>>();
    var queryRepositoryMock = new Mock<IQueryRepository<ParkingModel>>();
    var factoryMock = new Mock<IRepositoryFactory>();

    var initialParkedCars = new List<ParkingModel>
    {
        new ParkingModel(1, "abc", 1),
        new ParkingModel(2, "abcde", 2)
    };

    queryRepositoryMock.Setup(x => x.GetAll()).Returns(initialParkedCars);
    commandRepositoryMock.Setup(x => x.GetByCarNumber("abc")).Returns(initialParkedCars.FirstOrDefault(car => car.CarNumber == "abc"));
    accountServiceMock.Setup(x => x.PayForParking(1, It.IsAny<DateTime>())).Returns(true);

    factoryMock.Setup(f => f.CreateQueryRepository<ParkingModel>())
               .Returns(queryRepositoryMock.Object);
    factoryMock.Setup(f => f.CreateCommandRepository<ParkingModel>())
               .Returns(commandRepositoryMock.Object);

    ParkingService parkingService = new ParkingService(accountServiceMock.Object, factoryMock.Object);

    //Act
    var result = parkingService.ExitParking("abc");

    // Assert
    Assert.Equal(boolResult, result);
}

    
[Fact]
public void ExitParking_CheckingForCarNumber_CarStillParked()
{
    //Arrange

    var boolResult = false;
    var accountServiceMock = new Mock<IAccountService>();
    var commandRepositoryMock = new Mock<ICommandRepository<ParkingModel>>();
    var queryRepositoryMock = new Mock<IQueryRepository<ParkingModel>>();
    var factoryMock = new Mock<IRepositoryFactory>();

    var initialParkedCars = new List<ParkingModel>
    {
        new ParkingModel(1, "abc", 1),
        new ParkingModel(2, "abcde", 2)
    };

    queryRepositoryMock.Setup(x => x.GetAll()).Returns(initialParkedCars);
    accountServiceMock.Setup(x => x.PayForParking(2, It.IsAny<DateTime>())).Returns(false);

    factoryMock.Setup(f => f.CreateQueryRepository<ParkingModel>())
               .Returns(queryRepositoryMock.Object);
    factoryMock.Setup(f => f.CreateCommandRepository<ParkingModel>())
               .Returns(commandRepositoryMock.Object);

    ParkingService parkingService = new ParkingService(accountServiceMock.Object, factoryMock.Object);

    //Act
    var result = parkingService.ExitParking("abcred");

    // Assert
    Assert.Equal(boolResult, result);
    commandRepositoryMock.Verify(repo => repo.Delete(It.IsAny<ParkingModel>()), Times.Never);
}
}
