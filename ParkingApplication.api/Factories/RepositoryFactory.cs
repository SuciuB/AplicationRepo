using ParkingApplication.Api.Interfaces;
using Repositories;
using ParkingApplication.Api.Models;
using ParkingApplication.Api.Repositories;
using Microsoft.Extensions.Options;
using ParkingApplication.Api.Configuration;

namespace ParkingApplication.Api.Factories
{
public class RepositoryFactory : IRepositoryFactory
{
    private readonly IDbContext _dbContext;

    public RepositoryFactory(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryRepository<T> CreateQueryRepository<T>()
    {
        if (typeof(T) == typeof(ParkingModel))
        {
            return (IQueryRepository<T>)new ParkingRepository(_dbContext);
        }

        if (typeof(T) == typeof(AccountModel))
        {
            return (IQueryRepository<T>)new AccountRepository(_dbContext);
        }

        throw new ArgumentException("No repository found for the specified model type.");
    }

    public ICommandRepository<T> CreateCommandRepository<T>()
    {
        if (typeof(T) == typeof(ParkingModel))
        {
            return (ICommandRepository<T>)new ParkingRepository(_dbContext);
        }

        // Add command repository creation for other models if necessary

        throw new ArgumentException("No repository found for the specified model type.");
    }
}
}
