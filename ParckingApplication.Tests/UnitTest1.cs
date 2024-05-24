using ParckingApplication;

namespace ParckingApplication.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // // Arrange
        // var result = 3;
        Program.Result = 3;

        // Act
        Program.AddFunction(new ParckedCar("Vasile", "abc"));
        // Assert
        Assert.Equal(Program.Result, Program.ListOfParckedCar.Count);
    }

    [Fact]
    public void Test2()
    {
        // // Arrange
        // var result = 3;
        Program.Result = 6;

        // Act
        Program.AddFunction(new ParckedCar("Tudor", "abc"));
        // Assert
        Assert.True(Program.Result > Program.ListOfParckedCar.Count);
    }
}