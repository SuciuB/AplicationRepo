using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingApplication.Api.Interfaces;
using ParkingApplication.Api.Repositories;
using ParkingApplication.Api.Models;


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