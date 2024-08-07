using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ParkingApplication.Services;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Factories;
using ParkingApplication.Api.Repositories;
using ParkingApplication.Api.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder();

builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddScoped<SqlConnection>(sp =>
{
    var connectionString = sp.GetRequiredService<IOptions<ParkingApplication.Api.Configuration.ConnectionStrings>>().Value.DefaultConnection;
    return new SqlConnection(connectionString);
});

builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IParkingService, ParkingService>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Parking Application API",
        Description = "An API for managing parking services",
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Parking Application API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

// Dummy class to be used in tests
public partial class Program { }
