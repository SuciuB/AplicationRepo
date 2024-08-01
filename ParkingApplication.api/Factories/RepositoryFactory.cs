using ParkingApplication.Api.Interfaces;
using Repositories;
using ParkingApplication.Api.Models;
using ParkingApplication.Api.Repositories;

namespace ParkingApplication.Api.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IQueryRepository<T> CreateQueryRepository<T>()
        {
            if (typeof(T) == typeof(ParkingModel))
            {
                return (IQueryRepository<T>)new ParkingRepository();
            }
            if (typeof(T) == typeof(AccountModel))
            {
                return (IQueryRepository<T>)new AccountRepository();
            }

            throw new ArgumentException("No repository found for the specified model type.");
        }

        public ICommandRepository<T> CreateCommandRepository<T>()
        {
            if (typeof(T) == typeof(ParkingModel))
            {
                return (ICommandRepository<T>)new ParkingRepository();
            }
            throw new ArgumentException("No repository found for the specified model type.");
        }
    }
}
