using ParkingApplication.Api.Interfaces;
using Repositories;
using ParkingApplication.Api.Models;
using ParkingApplication.Api.Repositories;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using ParkingApplication.Api.Configuration;

namespace ParkingApplication.Api.Factories;
  public class RepositoryFactory : IRepositoryFactory
{
    private readonly SqlConnection _connection;

    public RepositoryFactory(SqlConnection connection)
    {
        _connection = connection;
    }

public IQueryRepository<T> CreateQueryRepository<T>()
{
    if (typeof(T) == typeof(ParkingModel))
    {
        return (IQueryRepository<T>)new ParkingRepository(_connection);
    }

    if (typeof(T) == typeof(AccountModel))
    {
        return (IQueryRepository<T>)new AccountRepository(_connection);
    }

    throw new ArgumentException("No repository found for the specified model type.");
}

public ICommandRepository<T> CreateCommandRepository<T>()
{
    if (typeof(T) == typeof(ParkingModel))
    {
        return (ICommandRepository<T>)new ParkingRepository(_connection);
    }

    throw new ArgumentException("No repository found for the specified model type.");
}
}
