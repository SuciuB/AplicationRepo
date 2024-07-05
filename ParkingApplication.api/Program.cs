using Microsoft.Extensions.DependencyInjection;
using System.Security.Authentication.ExtendedProtection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ParkingApplication;

public static class Program
{
    

    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        // Register services
        builder.Services.AddControllers();
        builder.Services.AddScoped<IAccountService, AccountService>();
        builder.Services.AddScoped<IParkingService, ParkingService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        //app.UseAuthorization();
        

        app.MapControllers();

        app.Run();

        
    }

}
