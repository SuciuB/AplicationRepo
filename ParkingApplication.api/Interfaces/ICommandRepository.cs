using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingApplication.Api.Models;

namespace ParkingApplication.Api.Interfaces
{
    public interface ICommandRepository<T>
    {
        ParkingModel GetByCarNumber(string carNumber);
        void Create(T model);
        void Delete(T model);
    }
}