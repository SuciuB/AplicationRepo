using Xunit;
using Moq;
using ParkingApplication.Services;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Models;
using System;
using System.Collections.Generic;

namespace ParkingApplication.Tests
{
public class AccountTests
{
[Fact]
public void PayForParking_AmountToPay_PayForHoursParked()
{
    // Arrange
    var factoryMock = new Mock<IRepositoryFactory>();
    var queryRepositoryMock = new Mock<IQueryRepository<AccountModel>>();
    var initialAccounts = new List<AccountModel>
    {
        new AccountModel(1, 500),
        new AccountModel(2, 300)
    };

    queryRepositoryMock.Setup(x => x.GetAll()).Returns(initialAccounts);
    factoryMock.Setup(f => f.CreateQueryRepository<AccountModel>())
                .Returns(queryRepositoryMock.Object);

    var accountService = new AccountService(factoryMock.Object);

    // Act
    var result = accountService.PayForParking(2, DateTime.Now.AddHours(-4));

    // Assert
    Assert.True(result);
}

[Fact]
public void PayForParking_AmountToPay_NotHavingMoney()
{
    // Arrange
    var factoryMock = new Mock<IRepositoryFactory>();
    var queryRepositoryMock = new Mock<IQueryRepository<AccountModel>>();
    var initialAccounts = new List<AccountModel>
    {
        new AccountModel(3, 10)
    };

    queryRepositoryMock.Setup(x => x.GetAll()).Returns(initialAccounts);
    factoryMock.Setup(f => f.CreateQueryRepository<AccountModel>())
                .Returns(queryRepositoryMock.Object);

    var accountService = new AccountService(factoryMock.Object);

    // Act
    var result = accountService.PayForParking(3, DateTime.Now.AddHours(-4));

    // Assert
    Assert.False(result);
}

[Fact]
public void PayForParking_AmountToPay_NullId()
{
    // Arrange
    var factoryMock = new Mock<IRepositoryFactory>();
    var queryRepositoryMock = new Mock<IQueryRepository<AccountModel>>();
    var initialAccounts = new List<AccountModel>();

    queryRepositoryMock.Setup(x => x.GetAll()).Returns(initialAccounts);
    factoryMock.Setup(f => f.CreateQueryRepository<AccountModel>())
                .Returns(queryRepositoryMock.Object);

    var accountService = new AccountService(factoryMock.Object);

    // Act
    var result = accountService.PayForParking(3, DateTime.Now);

    // Assert
    Assert.False(result);
}

[Fact]
public void CalculateParkingFee_FirstHourFree_ReturnSameAmount()
{
    // Arrange
    TimeSpan duration = TimeSpan.FromHours(1);
    var factoryMock = new Mock<IRepositoryFactory>();
    var accountService = new AccountService(factoryMock.Object);

    // Act
    double fee = accountService.CalculateParkingFee(duration);

    // Assert
    Assert.Equal(0, fee);
}
}
}
