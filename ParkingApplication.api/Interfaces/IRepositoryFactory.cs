using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApplication.Api.Interfaces
{
    public interface IRepositoryFactory
    {
        IQueryRepository<T> CreateQueryRepository<T>();
        ICommandRepository<T> CreateCommandRepository<T>();
    }
}