using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using ParkingApplication.Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace ParkingApplication.IntegrationTests;
public class ParkingControllerIntegrationTests
{

    [Fact]
    public async Task GetListOfParkedCars_ReturnsOkResponse_WithListOfCars()
    {
        // Arrange
        HttpClient client = new()
        {
            BaseAddress = new Uri("http://localhost:5149")
        };

        // Act
        var response = await client.GetAsync("api/parked-car");

        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.Contains("abc", responseString);
        Assert.Contains("abcd", responseString);
    }

    [Fact]
    public async Task AddToParking_WhenParkingAvailable_ReturnsOk()
    {
        // Arrange
        var car = new ParkingModel(3, "abcf", 3);
        HttpClient client = new()
        {
            BaseAddress = new Uri("http://localhost:5149")
        };

        // Act
        var response = await client.PostAsJsonAsync("/api/parked-car/parking", car);

        // Assert
        response.EnsureSuccessStatusCode();

        await client.DeleteAsync($"/api/parked-car/{car.CarNumber}");
    }

    [Fact]
    public async Task ExitParking_WhenCarExists_ReturnsOk()
    {
        // Arrange
        var carNumber = "abc";
        HttpClient client = new()
        {
            BaseAddress = new Uri("http://localhost:5149")
        };

        // Act
        var response = await client.DeleteAsync($"/api/parked-car/{carNumber}");

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal("Car exited from parking successfully.", await response.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task ExitParking_WhenCarDoesNotExist_ReturnsNotFound()
    {
        // Arrange
        var carNumber = "nonexistent";
        HttpClient client = new()
        {
            BaseAddress = new Uri("http://localhost:5149")
        };

        // Act
        var response = await client.DeleteAsync($"/api/parked-car/{carNumber}");

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.Equal("Car not found or payment not processed.", responseString);
    }
}

