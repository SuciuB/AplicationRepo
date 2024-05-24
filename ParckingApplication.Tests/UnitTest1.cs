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
        parcking.AddFunction("Tudor", "abc");
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
        parcking.AddFunction("Tudor");
        // Assert
        Assert.Equal(listCount , parcking.ListOfParckedCar.Count);
    }
}