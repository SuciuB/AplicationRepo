
using Microsoft.Extensions.DependencyInjection;
using System.Security.Authentication.ExtendedProtection;

namespace ParkingApplication;

public static class Program
{
    

    public static void Main()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddTransient<IAccountService, AccountService>();
        serviceCollection.AddTransient<ParkingService>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var parkingService = serviceProvider.GetService<ParkingService>();
    }

    



}
