using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace ParkingApplication.IntegrationTests;
public class AccountIntegrationTests
{
    [Fact]
    public async Task GetListOfAccounts_ReturnsOkResponse_WithListOfAccounts()
    {
        // Arrange
        HttpClient client = new()
        { 
            BaseAddress = new Uri("http://localhost:5149")
        };

        // Act
        var response = await client.GetAsync("api/Accounts");

        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.Contains("1", responseString);
        Assert.Contains("2", responseString);
    }

    [Fact]
    public async Task PayForParking_BasedOnUserId_ReturnsOk()
    {
        // Arrange
        var payload = new
        {
            userId = 1,
            inTime = DateTime.Now.AddHours(-3).ToString("yyyy-MM-ddTHH:mm:ss")
        };

        string jsonPayload = JsonConvert.SerializeObject(payload);
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:5149");

            // Act
            var response = await client.PostAsync("/api/Accounts/Payments", content);

            // Log the response content for debugging
            string responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Content: {responseContent}");

            // Assert
            Assert.Equal("Payment successful.", responseContent);
            response.EnsureSuccessStatusCode();
        }
    }
    public class PayForParkingRequest
    {
        public int UserId { get; set; }
        public DateTime InTime { get; set; }
    }
}
