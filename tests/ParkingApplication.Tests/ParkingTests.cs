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
            var accountServiceMock = new Mock<IAccountService>();
            var commandRepositoryMock = new Mock<ICommandRepository<ParkingModel>>();
            var queryRepositoryMock = new Mock<IQueryRepository<ParkingModel>>();
            var initialParkedCars = new List<ParkingModel>
            {
                new ParkingModel(1, "abc"),
                new ParkingModel(2, "abcde")
            };
            queryRepositoryMock.Setup(x => x.GetAll()).Returns(initialParkedCars);
            commandRepositoryMock.Setup(x => x.Create(It.IsAny<ParkingModel>())).Callback<ParkingModel>(car => initialParkedCars.Add(car));
            ParkingService parkingService = new ParkingService(accountServiceMock.Object, commandRepositoryMock.Object, queryRepositoryMock.Object);
            parkingService.MaxSlots = 2;
            
            // Act
            parkingService.AddToParking(4, "abcew");

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
            var initialParkedCars = new List<ParkingModel>
            {
                new ParkingModel(1, "abc"),
                new ParkingModel(2, "abcde")
            };
            queryRepositoryMock.Setup(x => x.GetAll()).Returns(initialParkedCars);
            commandRepositoryMock.Setup(x => x.Create(It.IsAny<ParkingModel>())).Callback<ParkingModel>(car => initialParkedCars.Add(car));
            ParkingService parkingService = new ParkingService(accountServiceMock.Object, commandRepositoryMock.Object, queryRepositoryMock.Object);
            
            // Act
            parkingService.AddToParking(4, "abcew");

            // Assert
            commandRepositoryMock.Verify(repo => repo.Create(It.IsAny<ParkingModel>()), Times.Once);
            Assert.Equal(expectedCarSlots, parkingService.GetAllCars().Count);
        }


    [Fact]
    public void ExitParking_ExitingParking_ExitParkingDate()
    {
        var boolResult = true;
        var accountServiceMock = new Mock<IAccountService>();
        var commandRepositoryMock = new Mock<ICommandRepository<ParkingModel>>();
        var queryRepositoryMock = new Mock<IQueryRepository<ParkingModel>>();
        var initialParkedCars = new List<ParkingModel>
        {
            new ParkingModel(1, "abc"),
            new ParkingModel(2, "abcde") 
        };
        queryRepositoryMock.Setup(x => x.GetAll()).Returns(initialParkedCars);
        accountServiceMock.Setup(x => x.PayForParking(1, It.IsAny<DateTime>())).Returns(true);
        ParkingService parkingService = new ParkingService(accountServiceMock.Object, commandRepositoryMock.Object, queryRepositoryMock.Object);

        var result = parkingService.ExitParking("abc");

        Assert.Equal(boolResult , result);
    }
    
    [Fact]
    public void ExitParking_CkeckingForCarNumber_CarStillParked()
    {
        var boolResult = false;
        var accountServiceMock = new Mock<IAccountService>();
        var commandRepositoryMock = new Mock<ICommandRepository<ParkingModel>>();
        var queryRepositoryMock = new Mock<IQueryRepository<ParkingModel>>();
        var initialParkedCars = new List<ParkingModel>
        {
            new ParkingModel(1, "abc"),
            new ParkingModel(2, "abcde")
        };
        queryRepositoryMock.Setup(x => x.GetAll()).Returns(initialParkedCars);
        accountServiceMock.Setup(x => x.PayForParking(2, It.IsAny<DateTime>())).Returns(false);
        ParkingService parkingService = new ParkingService(accountServiceMock.Object, commandRepositoryMock.Object, queryRepositoryMock.Object);

        var result = parkingService.ExitParking("abcred");

        Assert.Equal(boolResult , result);
    }
}
